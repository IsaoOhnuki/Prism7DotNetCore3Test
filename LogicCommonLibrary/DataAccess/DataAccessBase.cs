using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace LogicCommonLibrary.DataAccess
{
    public abstract class ScalarDataAccess : DataAccessBase
    {
        public ScalarDataAccess(DatabaseConnection connection, string query, SqlParameter[] parameter = null)
            : base(connection, query, parameter)
        {
        }

        public object DoScalar()
        {
            return ScalarCommand();
        }
    }

    public abstract class QueryDataAccess : DataAccessBase
    {
        public QueryDataAccess(DatabaseConnection connection, string query, SqlParameter[] parameter = null)
            : base(connection, query, parameter)
        {
        }

        public DataTable DoQuery()
        {
            return QueryCommand();
        }
    }

    public abstract class QueryDataAccess<T> : DataAccessBase
        where T : new()
    {
        public QueryDataAccess(DatabaseConnection connection, string query, SqlParameter[] parameter = null)
            : base(connection, query, parameter)
        {
        }

        public List<T> DoQuery()
        {
            return QueryCommand<T>();
        }
    }

    public abstract class NonQueryDataAccess : DataAccessBase
    {
        public NonQueryDataAccess(DatabaseConnection connection, string query, SqlParameter[] parameter = null)
            : base(connection, query, parameter)
        {
        }

        public int DoNonQuery()
        {
            return NonQueryCommand();
        }
    }

    public class DataAccessBase
    {
        private readonly string _query;
        private readonly SqlParameter[] _parameter;

        public DatabaseConnection Connection { get; private set; }

        protected DataAccessBase(DatabaseConnection connection, string query, SqlParameter[] parameter = null)
        {
            Connection = connection;
            _query = query;
            _parameter = parameter;
        }

        protected object ScalarCommand()
        {
            SqlCommand sqlCommand = new SqlCommand(_query, Connection.Connection);
            if (_parameter != null)
            {
                sqlCommand.Parameters.AddRange(_parameter);
            }
            object result = sqlCommand.ExecuteScalar();
            return result;
        }

        protected DataTable QueryCommand()
        {
            SqlCommand sqlCommand = new SqlCommand(_query, Connection.Connection);
            if (_parameter != null)
            {
                sqlCommand.Parameters.AddRange(_parameter);
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        protected int NonQueryCommand()
        {
            SqlCommand sqlCommand = Connection.Transaction != null ?
                new SqlCommand(_query, Connection.Connection, Connection.Transaction) :
                new SqlCommand(_query, Connection.Connection);
            if (_parameter != null)
            {
                sqlCommand.Parameters.AddRange(_parameter);
            }
            int result = sqlCommand.ExecuteNonQuery();
            return result;
        }

        protected List<T> QueryCommand<T>()
            where T : new()
        {
            SqlCommand sqlCommand = new SqlCommand(_query, Connection.Connection);
            if (_parameter != null)
            {
                sqlCommand.Parameters.AddRange(_parameter);
            }

            List<Tuple<PropertyInfo, int>> types = GetPublicPropInfo<T>();
            List<T> result = new List<T>();

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                types = CheckSchema(sqlDataReader.GetColumnSchema(), types);

                sqlDataReader.GetColumnSchema();
                if (sqlDataReader.Read())
                {
                    T t = new T();
                    foreach (Tuple<PropertyInfo, int> type in types)
                    {
                        type.Item1.SetValue(t, sqlDataReader[type.Item2]);
                    }
                    result.Add(t);
                }
            }
            return result;
        }

        protected List<Tuple<PropertyInfo, int>> GetPublicPropInfo<T>()
        {
            var type = Type.GetType(nameof(T));
            PropertyInfo[] props = type.GetProperties(BindingFlags.Public);
            List<Tuple<PropertyInfo, int>> result = new List<Tuple<PropertyInfo, int>>();
            foreach (PropertyInfo prop in props)
            {
                var r = new Tuple<PropertyInfo, int>(prop, 0);
                result.Add(r);
            }
            return result;
        }

        protected List<Tuple<PropertyInfo, int>> CheckSchema(IEnumerable<DbColumn> schema, IEnumerable<Tuple<PropertyInfo, int>> types)
        {
            List<Tuple<PropertyInfo, int>> result = new List<Tuple<PropertyInfo, int>>();
            foreach (Tuple<PropertyInfo, int> type in types)
            {
                DbColumn col = schema.Where(x => x.ColumnName == type.Item1.Name).FirstOrDefault();
                if (col == null)
                {
                    continue;
                }
                if (col.DataType != type.Item1.PropertyType)
                {
                    continue;
                }
                if (!col.ColumnOrdinal.HasValue)
                {
                    continue;
                }
                var r = new Tuple<PropertyInfo, int>(type.Item1, col.ColumnOrdinal.Value);
                result.Add(r);
            }
            return result;
        }
    }
}
