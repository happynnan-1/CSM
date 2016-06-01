using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    internal class SqliteDialect : SqlDialectBase
    {
        public override string GetIdentitySql(string tableName)
        {
            return "SELECT LAST_INSERT_ROWID() AS [Id]";
        }

        public override string GetPagingSql(string sql, int page, int resultsPerPage, IDictionary<string, object> parameters)
        {
            int startValue = page * resultsPerPage;
            return GetSetSql(sql, startValue, resultsPerPage, parameters);
        }

        public override string GetSetSql(string sql, int firstResult, int maxResults, IDictionary<string, object> parameters)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentNullException("sql");
            }

            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            var result = string.Format("{0} LIMIT @Offset, @Count", sql);
            parameters.Add("@Offset", firstResult);
            parameters.Add("@Count", maxResults);
            return result;
        }

        public override string GetColumnName(string prefix, string columnName, string alias)
        {
            if (string.IsNullOrWhiteSpace(columnName))
            {
                throw new ArgumentNullException(columnName, "columnName cannot be null or empty.");
            }
            var result = new StringBuilder();
            result.AppendFormat(columnName);
            if (!string.IsNullOrWhiteSpace(alias))
            {
                result.AppendFormat(" AS {0}", QuoteString(alias));
            }
            return result.ToString();
        }

        public override string GetPagingSql(string sql, int page, int resultsPerPage, out object parameters)
        {
            int startValue = page * resultsPerPage;
            return GetSetSql(sql, startValue, resultsPerPage,out parameters);
        }

        public override string GetSetSql(string sql, int firstResult, int maxResults, out object parameters)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentNullException("sql");
            }

            var result = string.Format("{0} LIMIT @Offset, @Count", sql);
            parameters = new { firstResult, maxResults };
            return result;
        }
    }
}
