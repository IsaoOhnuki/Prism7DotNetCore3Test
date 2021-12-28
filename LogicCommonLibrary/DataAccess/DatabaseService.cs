using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LogicCommonLibrary.DataAccess
{
    public class DatabaseService
    {
        protected Dictionary<Type, string> TypeString { get; } =
            new Dictionary<Type, string>
            {
                { typeof(int), "INT" },
            };

        public string CreateTableSql<T>(string databaseSchemaName, T table)
        {
            StringBuilder sql = new StringBuilder("CREATE TABLE");
            sql.AppendLine(databaseSchemaName + "." + nameof(table));
            sql.AppendLine("(");

            List<string> keys = new List<string>();
            PropertyInfo[] props = table.GetType().GetProperties(BindingFlags.Public);
            sql.AppendLine(
                string.Join(",\r\n",
                    props.Where(x =>
                        TypeString.ContainsKey(x.PropertyType) &&
                            !(Attribute.GetCustomAttribute(x, typeof(NotMappedAttribute)) is NotMappedAttribute)).
                        Select(x =>
                        {
                            if (Attribute.GetCustomAttribute(x, typeof(KeyAttribute)) is KeyAttribute)
                            {
                                keys.Add(x.Name);
                            }
                            string result = x.Name + " " + TypeString[x.PropertyType];
                            if (x.PropertyType == typeof(string))
                            {
                                if (Attribute.GetCustomAttribute(x, typeof(StringLengthAttribute)) is StringLengthAttribute len)
                                {
                                    result += "(" + len.MaximumLength.ToString() + ") NULL";
                                }
                                else
                                {
                                    result += "(MAX) NULL";
                                }
                            }
                            else
                            {
                                result += Nullable.GetUnderlyingType(x.PropertyType) != null ? " NULL" : " NOT NULL";
                            }
                            return result;
                        })) +
                            (keys.Count > 0 ? ",\r\n PRIMARY KEY(" + string.Join(",", keys) + ")" : "")
                        );

            sql.AppendLine("\r\n);");

            return sql.ToString();
        }
    }
}
