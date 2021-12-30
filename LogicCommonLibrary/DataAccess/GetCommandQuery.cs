using LogicCommonLibrary.DataAccess.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LogicCommonLibrary.DataAccess
{
    public class GetCommandQuery<TModel>
        where TModel : new()
    {
        public GetCommandQuery()
        {
        }

        public static Dictionary<Type, SqlDbType> DbTypes { get; } = new Dictionary<Type, SqlDbType>()
        {
            { typeof(int), SqlDbType.Int },
            { typeof(int?), SqlDbType.Int },
            { typeof(string), SqlDbType.NChar },
            { typeof(DateTime), SqlDbType.DateTime },
            { typeof(DateTime?), SqlDbType.DateTime },
            { typeof(decimal), SqlDbType.Decimal },
            { typeof(decimal?), SqlDbType.Decimal },
        };

        public static bool GetInsertQuery(out string query, out List<SqlParameter> sqlParameters)
        {
            query = "";
            sqlParameters = new List<SqlParameter>();
            List<string> columns = new List<string>();
            List<string> parameters = new List<string>();

            List<PropertyInfo> propInfos = new CheckModelSchema<TModel>().GetPublicPropInfo();
            foreach (var prop in propInfos)
            {
                if (Attribute.GetCustomAttribute(prop, typeof(InsertQueryParameterAttribute)) is InsertQueryParameterAttribute insertQueryParameter)
                {
                    columns.Add(prop.Name);
                    parameters.Add(insertQueryParameter.Parameter);
                }
                else if ((Attribute.GetCustomAttribute(prop, typeof(DatabaseGeneratedAttribute)) is DatabaseGeneratedAttribute databaseGeneratedAttribute &&
                    databaseGeneratedAttribute.DatabaseGeneratedOption != DatabaseGeneratedOption.None) ||
                    prop.Name.ToLower() == "id")
                {
                    // 
                }
                else
                {
                    columns.Add(prop.Name);
                    string paramName = "@" + prop.Name;
                    sqlParameters.Add(new SqlParameter(paramName, DbTypes[prop.PropertyType]));
                    parameters.Add(paramName);
                }
            }

            StringBuilder str = new StringBuilder();
            TModel model = new TModel();
            str.AppendLine("INSERT INTO " + model.GetType().Name);
            str.AppendLine("(");
            str.AppendLine(string.Join(",\r\n", columns));
            str.AppendLine(")");
            str.AppendLine("VALUES(");
            str.AppendLine(string.Join(",\r\n", parameters));
            str.AppendLine(");");
            query = str.ToString();

            return true;
        }

        public static bool GetDeleteQuery(out string query, out List<SqlParameter> sqlParameters)
        {
            query = "";
            sqlParameters = new List<SqlParameter>();
            List<string> wheres = new List<string>();

            List<PropertyInfo> propInfos = new CheckModelSchema<TModel>().GetPublicPropInfo();
            foreach (var prop in propInfos)
            {
                string paramName = "@" + prop.Name;
                if (Attribute.GetCustomAttribute(prop, typeof(KeyAttribute)) is KeyAttribute keyAttribute)
                {
                    wheres.Add(prop.Name + " = " + paramName);
                    sqlParameters.Add(new SqlParameter(paramName, DbTypes[prop.PropertyType]));
                }
                else if (Attribute.GetCustomAttribute(prop, typeof(OptimistAttribute)) is OptimistAttribute optimistAttribute &&
                    optimistAttribute.DeleteWhere)
                {
                    wheres.Add(prop.Name + " = " + paramName);
                    sqlParameters.Add(new SqlParameter(paramName, DbTypes[prop.PropertyType]));
                }
            }

            StringBuilder str = new StringBuilder();
            TModel model = new TModel();
            str.AppendLine("DELETE FROM " + model.GetType().Name);
            if (wheres.Count > 0)
            {
                str.AppendLine("WHERE");
                str.AppendLine(string.Join(" AND\r\n", wheres));
            }
            str.AppendLine(";");
            query = str.ToString();

            return true;
        }

        public static bool GetUpdateQuery(out string query, out List<SqlParameter> sqlParameters)
        {
            query = "";
            sqlParameters = new List<SqlParameter>();
            List<string> columns = new List<string>();
            List<string> wheres = new List<string>();

            List<PropertyInfo> propInfos = new CheckModelSchema<TModel>().GetPublicPropInfo();
            foreach (var prop in propInfos)
            {
                string paramName = "@" + prop.Name;
                if (Attribute.GetCustomAttribute(prop, typeof(KeyAttribute)) is KeyAttribute keyAttribute)
                {
                    wheres.Add(prop.Name + " = " + paramName);
                    sqlParameters.Add(new SqlParameter(paramName, DbTypes[prop.PropertyType]));
                }
                else if (Attribute.GetCustomAttribute(prop, typeof(UpdateQueryParameterAttribute)) is UpdateQueryParameterAttribute updateQueryParameterAttribute)
                {
                    columns.Add(prop.Name + " = " + updateQueryParameterAttribute.Parameter);
                }
                else
                {
                    columns.Add(prop.Name + " = " + paramName);
                    sqlParameters.Add(new SqlParameter(paramName, DbTypes[prop.PropertyType]));
                }
                if (Attribute.GetCustomAttribute(prop, typeof(OptimistAttribute)) is OptimistAttribute)
                {
                    wheres.Add(prop.Name + " = " + paramName);
                    if (sqlParameters.Any(x => x.ParameterName == paramName))
                    {
                        throw new DuplicateNameException();
                    }
                    sqlParameters.Add(new SqlParameter(paramName, DbTypes[prop.PropertyType]));
                }
            }

            StringBuilder str = new StringBuilder();
            TModel model = new TModel();
            str.AppendLine("UPDATE " + model.GetType().Name);
            str.AppendLine("SET");
            str.AppendLine(string.Join(",\r\n", columns));
            if (wheres.Count > 0)
            {
                str.AppendLine("WHERE");
                str.AppendLine(string.Join(" AND\r\n", wheres));
            }
            str.AppendLine(";");
            query = str.ToString();

            return true;
        }

        public static SqlParameter[] GetQueryParameter(IEnumerable<SqlParameter> sqlParameters, TModel model)
        {
            foreach (var param in sqlParameters)
            {
                param.Value = model.GetType().GetProperty(param.ParameterName.Substring(1)).GetValue(model);
            }
            return sqlParameters.ToArray();
        }
    }
}
