using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;


namespace DataAccess
{
    public class Transaction : IDisposable
    {
        [ThreadStatic]
        static Dictionary<string, Stack<Transaction>> _scopeStack ;
        Stack<Transaction> currentStack;
        private bool isDispose;
        Transaction parent;
        IDbConnection dbConnection;
        IDbTransaction dbTransaction;
        string connName;
        public ScopeOption Option { get; private set; }

        private static Dictionary<string, Stack<Transaction>> ScopeStack
        {
            get { return _scopeStack ?? (_scopeStack = new Dictionary<string, Stack<Transaction>>()); }
        }

        public Transaction(string dbName)
            : this(dbName, ScopeOption.Required)
        {
        }

        public Transaction(string dbName, ScopeOption option)
        {
            this.connName = dbName;
            Option = option;
            if (Option == ScopeOption.Required)
            {
                parent = GetCurrent(dbName);
            }
            if (!ScopeStack.ContainsKey(dbName))
                ScopeStack[dbName] = new Stack<Transaction>();
            currentStack = ScopeStack[dbName];
            currentStack.Push(this);
        }

        public static Transaction GetCurrent(string dbName)
        {
            if (!ScopeStack.ContainsKey(dbName))
                return null;
            var stack = ScopeStack[dbName];
            if (stack.Count != 0)
                return stack.Peek();
            return null;
        }

        public void Complete()
        {
            if (isDispose)
                throw new Exception("当前事务已经销毁,无法提交");
            //TODO:如果状态是Required,并且嵌套在事务里面执行,有可能会出现ts != this,要解决
            if (GetCurrent(this.connName) != this)
            {
                throw new Exception("当前提交的事务内还有未完成的其他事务,请先完成内部的事务");
            }
            Exception exp = null;
            if (Option == ScopeOption.RequiresNew || (Option == ScopeOption.Required && parent == null))
            {
                try
                {
                    Commit();
                }
                catch (Exception ex)
                {
                    exp = ex;
                }
            }
            Dispose();
            if (exp != null)
            {
                throw exp;
            }
        }

        internal IDbConnection GetConnection(string dbName)
        {
            if (parent != null)
                return parent.GetConnection(dbName);
            BuildConnection(dbName);
            return dbConnection;
        }

        internal IDbTransaction GetTransaction(string dbName)
        {
            if (parent != null)
                return parent.GetTransaction(dbName);
            BuildConnection(dbName);
            return dbTransaction;
        }
        private void BuildConnection(string dbName)
        {
            if (dbConnection == null)
            {
                connName = dbName;
                dbConnection = DataSource.GetConnection(dbName, false);
                dbConnection.Open();
                if (Option != ScopeOption.Suppress)
                {
                    dbTransaction = dbConnection.BeginTransaction();
                }
            }
            else
            {
                if (dbName != connName)
                    throw new Exception("Transaction只支持单一数据库操作,但是现在发现有2个数据库操作在内,分别是:" + connName + "," + dbName +
                                    ",请考虑使用TransactionScope或者UnitOfWork模式");
            }
        }

        private void Commit()
        {
            if (parent != null)
            {
                return;
            }
            if (dbTransaction != null && dbTransaction.Connection != null)
            {
                dbTransaction.Commit();
            }
            if (dbConnection != null)
            {
                dbConnection.Close();
            }
        }

        public void Dispose()
        {
            if (isDispose)
                return;
            if (parent != null)
            {
                if (ScopeStack.ContainsKey(connName) && ScopeStack[connName].Count != 0)
                    ScopeStack[connName].Pop();
                isDispose = true;
                return;
            }
            if (dbTransaction != null && dbTransaction.Connection != null && dbConnection.State==ConnectionState.Open)
            {
                dbTransaction.Rollback();
            }
            if (dbConnection != null)
            {
                dbConnection.Close();
            }
            if (ScopeStack.ContainsKey(connName) && ScopeStack[connName].Count != 0)
                ScopeStack[connName].Pop();
            isDispose = true;
        }
    }
}
