using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class IgnoreAttribute : Attribute
    {
        
    }
    public class KeyAttribute : Attribute
    {
        public KeyType KeyType { get;private set; }

        public KeyAttribute(KeyType type)
        {
            KeyType = type;
        }
    }

    public class TableAttribute : Attribute
    {
        public string TableName { get; set; }

        public TableAttribute(string tableName)
        {
            TableName = tableName;
        }
    }

    public class SchemaAttribute : Attribute
    {
        public string SchemaName { get; set; }

        public SchemaAttribute(string schemaName)
        {
            SchemaName = schemaName;
        }
    }

    public class ColumnAttribute : Attribute
   {
       public string ColumnName { get; set; }
       public ColumnAttribute(string columnName)
       {
           ColumnName = columnName;
       }
   }
}
