using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace DataAccess
{
    /// <summary>
    /// Automatically maps an entity to a table using a combination of reflection and naming conventions for keys.
    /// </summary>
    internal class AutoClassMapper<T> : ClassMapper<T> where T : class
    {
        public AutoClassMapper()
        {
            var type = typeof(T);
            var tableAttr = type.GetCustomAttributes(typeof (TableAttribute), false).FirstOrDefault();
            var tableName = tableAttr != null ? ((TableAttribute) tableAttr).TableName : type.Name;
            var schemaAttr = type.GetCustomAttributes(typeof (SchemaAttribute), false).FirstOrDefault();
            if (schemaAttr != null)
                Schema(((SchemaAttribute)schemaAttr).SchemaName);
            Table(tableName);
            AutoMap();
        }
    }
}