using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Reflection;
using System.Text;

namespace LogicCommonLibrary.DataAccess
{
    public class DbColumnInfo : DbColumn
    {
        public override object this[string property]
        {
            get => GetType().GetProperty(property).GetValue(this);
        }

        public void SetValue(string property, object value)
        {
            GetType().GetProperty(property).SetValue(this, value);
        }
    }

    public class DatabaseService
    {
        public bool CreateTable<T>(string database_name, string schema_name, T table)
        {
            StringBuilder sql = new StringBuilder("CREATE TABLE");
            sql.AppendLine(database_name + "." + schema_name + "." + nameof(table));

            PropertyInfo[] props = table.GetType().GetProperties(BindingFlags.Public);
            sql.AppendLine("(");
            string sepa = "";
            foreach (PropertyInfo prop in props)
            {
                string columnType;
                if (typeof(int) == prop.PropertyType)
                {
                    columnType = "int";
                }
                else
                {
                    throw new NotImplementedException();
                }
                sql.AppendLine(prop.Name + columnType + sepa);
                sepa = ",";
            }

            sql.AppendLine(");");

            return false;
        }
    }
}
