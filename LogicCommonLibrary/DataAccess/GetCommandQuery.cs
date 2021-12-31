using LogicCommonLibrary.DataAccess.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
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

        public static bool GetInsertQuery(out string query, out List<SqlParameter> sqlParameters)
        {
            query = "";
            sqlParameters = new List<SqlParameter>();
            List<string> columns = new List<string>();
            List<string> parameters = new List<string>();

            List<PropertyInfo> propInfos = CheckModelSchema.GetPublicPropInfo<TModel>();
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
                    sqlParameters.Add(new SqlParameter(paramName, default));
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

            List<PropertyInfo> propInfos = CheckModelSchema.GetPublicPropInfo<TModel>();
            foreach (var prop in propInfos)
            {
                string paramName = "@" + prop.Name;
                if (Attribute.GetCustomAttribute(prop, typeof(KeyAttribute)) is KeyAttribute keyAttribute)
                {
                    wheres.Add(prop.Name + " = " + paramName);
                    sqlParameters.Add(new SqlParameter(paramName, default));
                }
                else if (Attribute.GetCustomAttribute(prop, typeof(OptimistAttribute)) is OptimistAttribute optimistAttribute &&
                    optimistAttribute.DeleteWhere)
                {
                    wheres.Add(prop.Name + " = " + paramName);
                    sqlParameters.Add(new SqlParameter(paramName, default));
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

            List<PropertyInfo> propInfos = CheckModelSchema.GetPublicPropInfo<TModel>();
            foreach (var prop in propInfos)
            {
                string paramName = "@" + prop.Name;
                if (Attribute.GetCustomAttribute(prop, typeof(KeyAttribute)) is KeyAttribute keyAttribute)
                {
                    wheres.Add(prop.Name + " = " + paramName);
                    sqlParameters.Add(new SqlParameter(paramName, default));
                }
                else if (Attribute.GetCustomAttribute(prop, typeof(UpdateQueryParameterAttribute)) is UpdateQueryParameterAttribute updateQueryParameterAttribute)
                {
                    columns.Add(prop.Name + " = " + updateQueryParameterAttribute.Parameter);
                }
                else
                {
                    columns.Add(prop.Name + " = " + paramName);
                    sqlParameters.Add(new SqlParameter(paramName, default));
                }
                if (Attribute.GetCustomAttribute(prop, typeof(OptimistAttribute)) is OptimistAttribute)
                {
                    wheres.Add(prop.Name + " = " + paramName);
                    if (sqlParameters.Any(x => x.ParameterName == paramName))
                    {
                        throw new DuplicateNameException();
                    }
                    sqlParameters.Add(new SqlParameter(paramName, default));
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

        public static IEnumerable<SqlParameter> GetQueryParameter(IEnumerable<SqlParameter> sqlParameters,
            IEnumerable<DbColumn> dbColumns, TModel model)
        {
            List<SqlParameter> result = new List<SqlParameter>();
            foreach (var param in sqlParameters)
            {
                string columnName = param.ParameterName[1..];
                SqlDbType sqlDbType =
                    (SqlDbType)Enum.Parse(
                        typeof(SqlDbType),
                            dbColumns.First(x => x.ColumnName == columnName).DataTypeName,
                                true);

                object value = model.GetType().GetProperty(columnName).GetValue(model);
                result.Add(new SqlParameter(param.ParameterName, sqlDbType)
                {
                    Value = value ?? DBNull.Value,
                });
            }
            return result;
        }
    }
}
