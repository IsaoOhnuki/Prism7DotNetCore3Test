using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LogicCommonLibrary.DataAccess
{
    public class ModelColumnSchema
    {
        public PropertyInfo ColumnInfo { get; set; }

        public int ColumnIndex { get; set; }
    }

    public static class CheckModelSchema
    {
        public static List<ModelColumnSchema> GetTrueSchema<TModel>(IEnumerable<DbColumn> dbSchema)
            where TModel : new()
        {
            var propInfos = GetPublicPropInfo<TModel>();
            return CheckSchema(dbSchema, propInfos);
        }

        public static void CheckParamSchema(IEnumerable<DbColumn> dbSchema, IEnumerable<SqlParameter> sqlParameters)
        {
            foreach (SqlParameter param in sqlParameters)
            {
                var dbColumn = dbSchema.First(x => x.ColumnName == param.ParameterName[1..]);
                param.SqlDbType = (SqlDbType)Enum.Parse(typeof(SqlDbType), dbColumn.DataTypeName, true);
            }
        }

        public static IEnumerable<DbColumn> GetModelSchema<TModel>(SqlConnection sqlConnection)
            where TModel : new()
        {
            TModel model = new TModel();
            string selectQuery = "SELECT * FROM " + model.GetType().Name + ";";
            SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection);

            IEnumerable<DbColumn> result;
            bool selfOpen = false;
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    selfOpen = true;
                    sqlConnection.Open();
                }

                // クエリのスキーマを取得する
                using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                result = sqlDataReader.GetColumnSchema();
            }
            finally
            {
                if (selfOpen)
                {
                    sqlConnection.Close();
                }
            }
            return result;
        }

        public static List<PropertyInfo> GetPublicPropInfo<TModel>()
            where TModel : new()
        {
            // 型を確定させてTypeを取得する
            Type typeT = new TModel().GetType();
            // すべてのパブリックプロパティを取得する。
            PropertyInfo[] props = typeT.GetProperties();
            // プロパティ型とカラムインデックスのリストを取得する。
            List<PropertyInfo> result = new List<PropertyInfo>();
            foreach (PropertyInfo prop in props)
            {
                result.Add(prop);
            }
            return result;
        }

        public static List<ModelColumnSchema> CheckSchema(IEnumerable<DbColumn> schema, IEnumerable<PropertyInfo> types)
        {
            // プロパティ名をもとにDBのカラム型とプロパティ型を判定する。
            List<ModelColumnSchema> result = new List<ModelColumnSchema>();
            foreach (PropertyInfo type in types)
            {
                DbColumn col = schema.Where(x => x.ColumnName == type.Name).FirstOrDefault();
                if (col == null)
                {
                    // 同じDBカラム名が無ければパスする。
                    continue;
                }
                if (type.PropertyType.IsGenericType &&
                    type.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                    (col.DataType != Nullable.GetUnderlyingType(type.PropertyType) ||
                    !col.AllowDBNull.HasValue ||
                    !col.AllowDBNull.Value))
                {
                    // 同じDBカラム型で無ければパスする。
                    continue;
                }
                if (!type.PropertyType.IsGenericType &&
                    col.DataType != type.PropertyType)
                {
                    // 同じDBカラム型で無ければパスする。
                    continue;
                }
                if (!col.ColumnOrdinal.HasValue)
                {
                    // DBカラムインデックスが無ければパスする。
                    continue;
                }
                result.Add(new ModelColumnSchema()
                {
                    ColumnInfo = type,
                    ColumnIndex = col.ColumnOrdinal.Value,
                });
            }
            return result;
        }
    }
}
