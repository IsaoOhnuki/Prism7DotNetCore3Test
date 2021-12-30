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

    public class CheckModelSchema<TModel>
        where TModel : new()
    {
        public CheckModelSchema()
        {
        }

        public List<ModelColumnSchema> GetTrueSchema(IEnumerable<DbColumn> dbSchema)
        {
            var propInfos = GetPublicPropInfo();
            return CheckSchema(dbSchema, propInfos);
        }

        public void CheckParamSchema(IEnumerable<DbColumn> dbSchema, IEnumerable<SqlParameter> sqlParameters)
        {
            foreach (SqlParameter param in sqlParameters)
            {
                var dbColumn = dbSchema.First(x => x.ColumnName == param.ParameterName[1..]);
                param.SqlDbType = (SqlDbType)Enum.Parse(typeof(SqlDbType), dbColumn.DataTypeName);
            }
        }

        public List<PropertyInfo> GetPublicPropInfo()
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

        protected List<ModelColumnSchema> CheckSchema(IEnumerable<DbColumn> schema, IEnumerable<PropertyInfo> types)
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
