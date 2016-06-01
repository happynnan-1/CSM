using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DataAccess
{
    internal class DataSource
    {
        public static IDbConnection GetConnection(string name, bool isRead = true)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            var provider = ConfigurationManager.ConnectionStrings[name].ProviderName;
            var factory = DbProviderFactories.GetFactory(provider ?? "System.Data.SqlClient");
            var conn = factory.CreateConnection();
            conn.ConnectionString = connectionString;
            return conn;
        }

        public static string GetProvider(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ProviderName;
        }
        public static IDbTransaction GetTransaction(IDbConnection conn)
        {
            return conn.BeginTransaction();
        }
    }
}
