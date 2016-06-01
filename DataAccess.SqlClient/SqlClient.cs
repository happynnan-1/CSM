using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataAccess
{
    public class SqlClient
    {
        private string dbName;

        public SqlClient(string dbName)
        {
            this.dbName = dbName;
        }

        private IDbConnection GetConnection(bool isRead)
        {
            var conn = Transaction.GetCurrent(dbName) == null
                ? DataSource.GetConnection(dbName, isRead)
                : Transaction.GetCurrent(dbName).GetConnection(dbName);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            return conn;
        }

        private IDbTransaction GetTransaction(IDbConnection conn)
        {
            return Transaction.GetCurrent(dbName) == null
                ? DataSource.GetTransaction(conn)
                : Transaction.GetCurrent(dbName).GetTransaction(dbName);
        }

        public virtual IEnumerable<T> QueryAll<T>(bool isWriteDatabase) where T : class
        {
            return QueryOperator(isWriteDatabase, (conn, tran) =>
                DapperExtensions
                    .GetExtensions(DataSource.GetProvider(dbName))
                    .GetList<T>(conn, transaction: tran, buffered: true)
                );
        }

        public virtual IEnumerable<T> QueryAll<T>() where T : class
        {
            return QueryAll<T>(false);
        }

        public virtual IEnumerable<T> Query<T>(string sql, bool isWriteDatabase, dynamic parameters = null) where T : class
        {
            return QueryOperator(isWriteDatabase, (conn, tran) =>
                SqlMapper.Query<T>(conn, sql, parameters, buffered: true, transaction: tran)
                );
        }

        public virtual IEnumerable<T> Query<T>(string sql, dynamic parameters = null)
            where T : class
        {
            return Query<T>(sql, false, parameters);
        }

        public virtual IEnumerable<T> QueryByPage<T>(string sql, int page, int count, bool isWriteDatabase, dynamic parameters = null)
            where T : class
        {
            return QueryOperator(isWriteDatabase, (conn, tran) =>
                DapperExtensions
                    .GetExtensions(DataSource.GetProvider(dbName)).GetPage<T>(conn, sql, page, count, parameters: parameters, transaction: tran)
            );
        }

        public virtual IEnumerable<T> QueryByPage<T>(string sql, int page, int count, dynamic parameters = null)
            where T : class
        {
            return QueryByPage<T>(sql, page, count, false, parameters);
        }



        public virtual T GetEntityById<T>(bool isWriteDatabase, dynamic id) where T : class
        {
            return QueryOperator(isWriteDatabase, (conn, tran) =>
                DapperExtensions
                .GetExtensions(DataSource.GetProvider(dbName))
                .Get<T>(conn, id, transaction: tran));
        }

        public virtual T GetEntityById<T>(dynamic id) where T : class
        {
            return GetEntityById<T>(false, id);
        }

        public virtual T? QueryScalar<T>(string sql, bool isWriteDatabase, dynamic parameters = null) where T : struct
        {
            return
                QueryOperator(isWriteDatabase,
                    (conn, tran) =>
                        Enumerable.SingleOrDefault(SqlMapper.Query<T?>(conn, sql, parameters, transaction: tran)));
        }

        public virtual T? QueryScalar<T>(string sql, dynamic parameters = null) where T : struct
        {
            return QueryScalar<T>(sql, false, parameters);
        }

        public virtual int ExecuteWriteSql(string sql, dynamic parameters = null)
        {
            return
                ChangeOperator(true,
                    (conn, tran) =>
                        SqlMapper.Execute(conn, sql, parameters, transaction: tran));
        }



        protected virtual T QueryOperator<T>(bool isWriteDatabase, Func<IDbConnection, IDbTransaction, T> func)
        {
            IDbConnection conn = null;
            IDbTransaction tran = null;
            try
            {
                conn = GetConnection(!isWriteDatabase);
                tran = GetTransaction(conn);
                var result = func(conn, tran);
                return result;
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                throw ex;
            }
            finally
            {
                if (tran == null && conn != null)
                    conn.Close();
            }
        }

        protected virtual T ChangeOperator<T>(bool isWriteDatabase, Func<IDbConnection, IDbTransaction, T> action)
        {
            if (UnitOfWork.GetCurrent(dbName) != null && UnitOfWork.GetCurrent(dbName).Option != ScopeOption.Suppress)
            {
                UnitOfWork.GetCurrent(dbName).AddAction((c, t) => action(c, t));
                return default(T);
            }
            IDbConnection conn = null;
            IDbTransaction tran = null;
            try
            {
                conn = GetConnection(!isWriteDatabase);
                tran = GetTransaction(conn);
                var result = action(conn, tran);
                if (tran == null)
                    conn.Close();
                return result;
            }
            finally
            {
                if (tran == null && conn != null)
                    conn.Close();
            }
        }

        public virtual dynamic Add<T>(T entity) where T : class
        {

            return ChangeOperator(true, (conn, tran) => DapperExtensions
                 .GetExtensions(DataSource.GetProvider(dbName))
                 .Insert(conn, entity, transaction: tran));
        }

        public virtual bool Delete<T>(T entity) where T : class
        {
            return ChangeOperator(true, (conn, tran) => DapperExtensions
                .GetExtensions(DataSource.GetProvider(dbName))
                .Delete(conn, entity, transaction: tran));
        }

        public virtual bool Update<T>(T entity) where T : class
        {
            return ChangeOperator(true, (conn, tran) => DapperExtensions
                .GetExtensions(DataSource.GetProvider(dbName))
                .Update(conn, entity, transaction: tran));
        }
    }
}
