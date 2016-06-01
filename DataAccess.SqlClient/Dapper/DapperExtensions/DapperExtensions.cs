using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;


namespace DataAccess
{
    internal  class DapperExtensions
    {
        private static Dictionary<string,DapperExtensions> extensions=new Dictionary<string,DapperExtensions>();
        private  readonly  object _lock = new object();
        private static  readonly  object _staticLock = new object();

        private  Func<IDapperExtensionsConfiguration, IDapperImplementor> _instanceFactory;
        private  IDapperImplementor _instance;
        private  IDapperExtensionsConfiguration _configuration;
        
        public static DapperExtensions GetExtensions(string name)
        {
            if (extensions.ContainsKey(name))
                return extensions[name];
            lock (_staticLock)
            {
                if (extensions.ContainsKey(name))
                return extensions[name];
                var instance=new DapperExtensions();
                switch(name)
                {    case "MySql.Data.MySqlClient":
                        instance.SqlDialect=new MySqlDialect();
                        break;
                    case "postgresql":
                        instance.SqlDialect=new PostgreSqlDialect();
                        break;
                    case "sqlite":
                        instance.SqlDialect=new SqliteDialect();
                        break;
                    case "System.Data.SqlClient":
                        instance.SqlDialect=new SqlServerDialect();
                        break;
                    case "sqlce":
                        instance.SqlDialect=new SqlCeDialect();
                        break;
                    default:
                        instance.SqlDialect = new SqlServerDialect();
                        break;
                }
                extensions[name]=instance;
                return instance;
            }

        }
        /// <summary>
        /// Gets or sets the default class mapper to use when generating class maps. If not specified, AutoClassMapper<T> is used.
        /// DapperExtensions.Configure(Type, IList<Assembly>, ISqlDialect) can be used instead to set all values at once
        /// </summary>
        public  Type DefaultMapper
        {
            get
            {
                return _configuration.DefaultMapper;
            }

            set
            {
                Configure(value, _configuration.MappingAssemblies, _configuration.Dialect);
            }
        }

        /// <summary>
        /// Gets or sets the type of sql to be generated.
        /// DapperExtensions.Configure(Type, IList<Assembly>, ISqlDialect) can be used instead to set all values at once
        /// </summary>
        public  ISqlDialect SqlDialect
        {
            get
            {
                return _configuration.Dialect;
            }

            set
            {
                Configure(_configuration.DefaultMapper, _configuration.MappingAssemblies, value);
            }
        }
        
        /// <summary>
        /// Get or sets the Dapper Extensions Implementation Factory.
        /// </summary>
        public  Func<IDapperExtensionsConfiguration, IDapperImplementor> InstanceFactory
        {
            get
            {
                if (_instanceFactory == null)
                {
                    _instanceFactory = config => new DapperImplementor(new SqlGeneratorImpl(config));
                }

                return _instanceFactory;
            }
            set
            {
                _instanceFactory = value;
                Configure(_configuration.DefaultMapper, _configuration.MappingAssemblies, _configuration.Dialect);
            }
        }

        /// <summary>
        /// Gets the Dapper Extensions Implementation
        /// </summary>
        private  IDapperImplementor Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = InstanceFactory(_configuration);
                        }
                    }
                }

                return _instance;
            }
        }

        public DapperExtensions()
        {
            Configure(typeof(AutoClassMapper<>), new List<Assembly>(), new SqlServerDialect());
        }

        /// <summary>
        /// Add other assemblies that Dapper Extensions will search if a mapping is not found in the same assembly of the POCO.
        /// </summary>
        /// <param name="assemblies"></param>
        public void SetMappingAssemblies(IList<Assembly> assemblies)
        {
            Configure(_configuration.DefaultMapper, assemblies, _configuration.Dialect);
        }

        /// <summary>
        /// Configure DapperExtensions extension methods.
        /// </summary>
        /// <param name="defaultMapper"></param>
        /// <param name="mappingAssemblies"></param>
        /// <param name="sqlDialect"></param>
        public void Configure(IDapperExtensionsConfiguration configuration)
        {
            _instance = null;
            _configuration = configuration;
        }

        /// <summary>
        /// Configure DapperExtensions extension methods.
        /// </summary>
        /// <param name="defaultMapper"></param>
        /// <param name="mappingAssemblies"></param>
        /// <param name="sqlDialect"></param>
        public  void Configure(Type defaultMapper, IList<Assembly> mappingAssemblies, ISqlDialect sqlDialect)
        {
            Configure(new DapperExtensionsConfiguration(defaultMapper, mappingAssemblies, sqlDialect));
        }

        /// <summary>
        /// Executes a query for the specified id, returning the data typed as per T
        /// </summary>
        public  T Get<T>(IDbConnection connection, dynamic id, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var result = Instance.Get<T>(connection, id, transaction, commandTimeout);
            return (T)result;
        }

        /// <summary>
        /// Executes an insert query for the specified entity.
        /// </summary>
        public  void Insert<T>(IDbConnection connection, IEnumerable<T> entities, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            Instance.Insert<T>(connection, entities, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes an insert query for the specified entity, returning the primary key.  
        /// If the entity has a single key, just the value is returned.  
        /// If the entity has a composite key, an IDictionary&lt;string, object&gt; is returned with the key values.
        /// The key value for the entity will also be updated if the KeyType is a Guid or Identity.
        /// </summary>
        public  dynamic Insert<T>(IDbConnection connection, T entity, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return Instance.Insert<T>(connection, entity, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes an update query for the specified entity.
        /// </summary>
        public  bool Update<T>(IDbConnection connection, T entity, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return Instance.Update<T>(connection, entity, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes a delete query for the specified entity.
        /// </summary>
        public  bool Delete<T>(IDbConnection connection, T entity, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return Instance.Delete<T>(connection, entity, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes a delete query using the specified predicate.
        /// </summary>
        public  bool Delete<T>(IDbConnection connection, object predicate, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return Instance.Delete<T>(connection, predicate, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes a select query using the specified predicate, returning an IEnumerable data typed as per T.
        /// </summary>
        public  IEnumerable<T> GetList<T>( IDbConnection connection, object predicate = null,
            IList<ISort> sort = null, IDbTransaction transaction = null, int? commandTimeout = null,
            bool buffered = false) where T : class
        {
            return Instance.GetList<T>(connection, predicate, sort, transaction, commandTimeout, buffered);
        }

        /// <summary>
        /// Executes a select query using the specified predicate, returning an IEnumerable data typed as per T.
        /// Data returned is dependent upon the specified page and resultsPerPage.
        /// </summary>
        public  IEnumerable<T> GetPage<T>( IDbConnection connection, object predicate, IList<ISort> sort, int page, int resultsPerPage, IDbTransaction transaction = null, int? commandTimeout = null, bool buffered = false) where T : class
        {
            return Instance.GetPage<T>(connection, predicate, sort, page, resultsPerPage, transaction, commandTimeout, buffered);
        }
        //肖艳杰添加,根据SQL语句返回分页
        public  IEnumerable<T> GetPage<T>( IDbConnection connection, string sql, int page, int resultsPerPage,
            object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null,
            bool buffered = true) where T : class
        {
            return Instance.GetPage<T>(connection, sql, page, resultsPerPage,parameters, transaction, commandTimeout,
                buffered);
        }


        /// <summary>
        /// Executes a select query using the specified predicate, returning an IEnumerable data typed as per T.
        /// Data returned is dependent upon the specified firstResult and maxResults.
        /// </summary>
        public  IEnumerable<T> GetSet<T>( IDbConnection connection, object predicate, IList<ISort> sort, int firstResult, int maxResults, IDbTransaction transaction = null, int? commandTimeout = null, bool buffered = false) where T : class
        {
            return Instance.GetSet<T>(connection, predicate, sort, firstResult, maxResults, transaction, commandTimeout, buffered);
        }

        /// <summary>
        /// Executes a query using the specified predicate, returning an integer that represents the number of rows that match the query.
        /// </summary>
        public  int Count<T>( IDbConnection connection, object predicate, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return Instance.Count<T>(connection, predicate, transaction, commandTimeout);
        }

        /// <summary>
        /// Executes a select query for multiple objects, returning IMultipleResultReader for each predicate.
        /// </summary>
        public  IMultipleResultReader GetMultiple( IDbConnection connection, GetMultiplePredicate predicate, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return Instance.GetMultiple(connection, predicate, transaction, commandTimeout);
        }

        /// <summary>
        /// Gets the appropriate mapper for the specified type T. 
        /// If the mapper for the type is not yet created, a new mapper is generated from the mapper type specifed by DefaultMapper.
        /// </summary>
        public  IClassMapper GetMap<T>() where T : class
        {
            return Instance.SqlGenerator.Configuration.GetMap<T>();
        }

        /// <summary>
        /// Clears the ClassMappers for each type.
        /// </summary>
        public  void ClearCache()
        {
            Instance.SqlGenerator.Configuration.ClearCache();
        }

        /// <summary>
        /// Generates a COMB Guid which solves the fragmented index issue.
        /// See: http://davybrion.com/blog/2009/05/using-the-guidcomb-identifier-strategy
        /// </summary>
        public  Guid GetNextGuid()
        {
            return Instance.SqlGenerator.Configuration.GetNextGuid();
        }
    }
}
