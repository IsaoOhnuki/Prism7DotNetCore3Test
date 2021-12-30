using System.Data;
using System.Data.SqlClient;

namespace LogicCommonLibrary.DataAccess
{
    public class QueryParameter
    {
        public SqlParameter SqlParameter { get; private set; }

        public QueryParameter(string paramName, SqlDbType dbType, object value)
        {
            SqlParameter = new SqlParameter(paramName, dbType)
            {
                Value = value
            };
        }

        public static implicit operator SqlParameter(QueryParameter obj)
        {
            return obj.SqlParameter;
        }
    }
}
