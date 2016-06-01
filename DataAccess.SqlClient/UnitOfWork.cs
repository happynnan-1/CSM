using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataAccess
{
    public class UnitOfWork : IDisposable
    {
        [ThreadStatic]
        static Dictionary<string,Stack<UnitOfWork>> _unitOfWorkStack;
        List<Action<IDbConnection, IDbTransaction>> list = new List<Action<IDbConnection, IDbTransaction>>();
        bool isShadow;
        string connName;

        public static Dictionary<string, Stack<UnitOfWork>> UnitOfWorkStack
        {
            get
            {
                if (_unitOfWorkStack == null)
                    _unitOfWorkStack = new Dictionary<string, Stack<UnitOfWork>>();
                return _unitOfWorkStack;
            }
        }

        public UnitOfWork(string dbName)
            : this(dbName, ScopeOption.Required)
        {
        }
        public UnitOfWork(ScopeOption option)
            : this(null, option)
        {
        }

        public UnitOfWork(string dbName, ScopeOption option)
        {
            this.connName = dbName;
            Option = option;
            if (Option == ScopeOption.Required)
            {
                var current = GetCurrent(dbName);
                if (current == null)
                {
                    list = new List<Action<IDbConnection, IDbTransaction>>();
                }
                else
                {
                    list = current.list;
                    isShadow = true;
                }
            }
            if (!UnitOfWorkStack.ContainsKey(dbName))
                UnitOfWorkStack[dbName] = new Stack<UnitOfWork>();
            UnitOfWorkStack[dbName].Push(this);
        }

        public ScopeOption Option
        {
            get;
            private set;
        }

        public static UnitOfWork GetCurrent(string dbName)
        {
            if (!UnitOfWorkStack.ContainsKey(dbName))
                return null;
            var stack = UnitOfWorkStack[dbName];
            if (stack.Count != 0)
                return stack.Peek();
            return null;
        }

        public void Complete()
        {
            if (GetCurrent(connName) != this)
            {
                throw new Exception("当前提交的事务内还有未完成的其他事务,请先完成内部的事务");
            }
            if (Option == ScopeOption.RequiresNew || (Option == ScopeOption.Required && isShadow == false))
            {
                try
                {
                    Commit();
                }
                catch
                {
                    Dispose();
                    throw;
                }
            }
            Dispose();
        }

        public void AddAction(Action<IDbConnection, IDbTransaction> action)
        {
            list.Add(action);
        }

        private void Commit()
        {
            //循环遍历每条要执行的操作,然后再一个数据库连接中执行完成
            using (var conn = DataSource.GetConnection(connName, false))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    foreach (var action in list)
                    {
                        action(conn, tran);
                    }
                    tran.Commit();
                    conn.Close();
                    list.Clear();
                }
            }
            return;
        }

        public void Dispose()
        {
            if (!isShadow)
            {
                list.Clear();
            }
            if (GetCurrent(connName) == this)
            {
                UnitOfWorkStack[connName].Pop();
            }
        }
    }
}
