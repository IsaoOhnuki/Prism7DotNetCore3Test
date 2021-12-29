using System.Data;
using System.Data.SqlClient;

namespace LogicCommonLibrary.DataAccess
{
    public class QueryParameter
    {
        private readonly SqlParameter _sqlParameter;

        public QueryParameter(string paramName, SqlDbType dbType, object value)
        {
            _sqlParameter = new SqlParameter(paramName, dbType)
            {
                Value = value
            };
        }

        public static implicit operator SqlParameter(QueryParameter obj)
        {
            return obj._sqlParameter;
        }
    }
}
