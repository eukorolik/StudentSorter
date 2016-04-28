using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace StudentSorter.ORM
{
    class ORMBase
    {
        public string GetInsertQuery()
        {
            var type = this.GetType();
            var tableName = ((TableAttribute)Attribute.GetCustomAttributes(type)[0]).Name;
            var props = type.GetProperties();

            var sql = "INSERT INTO " + tableName + " (";
            var sqlValues = "\nVALUES (";
            foreach (PropertyInfo prop in props)
            {
                var columnName = ((ColumnAttribute)Attribute.GetCustomAttributes(prop)[0]).Name;
                if (columnName == "id")
                    continue;
                var value = prop.GetValue(this, null);
                if (value is Enum)
                    sqlValues += "'" + (byte)value + "'";
                else if (value == null)
                    sqlValues += "null";
                else
                    sqlValues += "'" + value + "'";

                sql += columnName;
                if (prop != props[props.Length - 1])
                {
                    sql += ",";
                    sqlValues += ",";
                }
            }

            sql += ")" + sqlValues + ");";

            return sql;
        }

        public string GetUpdateQuery(string[] fieldName)
        {
            var type = this.GetType();
            var tableName = ((TableAttribute)Attribute.GetCustomAttributes(type)[0]).Name;
            var props = type.GetProperties();

            var sql = "UPDATE " + tableName + " SET ";
            var id = 0;
            foreach (PropertyInfo prop in props)
            {
                var columnName = ((ColumnAttribute)Attribute.GetCustomAttributes(prop)[0]).Name;
                var sqlValue = "";
                if (columnName == "id")
                    id = (int)prop.GetValue(this, null);

                if (!fieldName.Contains(columnName))
                    continue;

                var value = prop.GetValue(this, null);
                if (value is Enum)
                    sqlValue += "'" + (byte)value + "'";
                else if (value == null)
                    sqlValue += "null";
                else
                    sqlValue += "'" + value + "'";

                sql += columnName + "=" + sqlValue;
                if (prop != props[props.Length - 1])
                    sql += ",";
            }

            sql += " WHERE id = " + id;
            
            return sql;
        }
    }
}
