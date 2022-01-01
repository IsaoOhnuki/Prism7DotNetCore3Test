using ModelLibrary.ModelBases;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LogicCommonLibrary.DataAccess
{
    public class ScalarDataAccess : DataAccessBase
    {
        public ScalarDataAccess(IDatabaseConnection connection,
            string query, IEnumerable<SqlParameter> parameter = null)
            : base(connection, query, parameter)
        {
        }

        public object GetScalar()
        {
            return ScalarCommand();
        }
    }

    public class QueryDataAccess : DataAccessBase
    {
        public QueryDataAccess(IDatabaseConnection connection,
            string query, IEnumerable<SqlParameter> parameter = null)
            : base(connection, query, parameter)
        {
        }

        public DataTable DoQuery()
        {
            return QueryCommand();
        }
    }

    public class QueryDataAccess<T> : DataAccessBase
        where T : new()
    {
        public QueryDataAccess(IDatabaseConnection connection,
            string query, IEnumerable<SqlParameter> parameter = null)
            : base(connection, query, parameter)
        {
        }

        public List<T> DoQuery()
        {
            return QueryCommand<T>();
        }
    }

    public class NonQueryDataAccess : DataAccessBase
    {
        public NonQueryDataAccess(IDatabaseConnection connection,
            string query, IEnumerable<SqlParameter> parameter = null)
            : base(connection, query, parameter)
        {
        }

        public int DoNonQuery(bool transaction)
        {
            return NonQueryCommand(transaction);
        }
    }

    public class DataAccessBase : IDataAccess
    {
        private readonly string _query;
        private readonly IEnumerable<SqlParameter> _parameter;

        public IDatabaseConnection Connection { get; private set; }

        public string GetLastQuery()
        {
            return "{[SQL]='" + _query + "'}";
        }

        public string GetLastQueryParam()
        {
            return _parameter == null ? "{}" :
                string.Join(",",
                    _parameter.Select(x =>
                        "{[Name]='" + x.ParameterName + "';" +
                        "[Type]='" + x.SqlDbType.ToString() + "';" +
                        "[Value]='" + (x.Value == null ? "null" : x.Value.ToString()) + "'}"));
        }

        protected DataAccessBase(IDatabaseConnection connection,
            string query, IEnumerable<SqlParameter> parameter = null)
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
                sqlCommand.Parameters.AddRange(_parameter.ToArray());
            }
            object result;
            bool selfOpen = false;
            try
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    selfOpen = true;
                    Connection.Open(false);
                }
                result = sqlCommand.ExecuteScalar();
            }
            finally
            {
                if (selfOpen)
                {
                    Connection.Close();
                }
            }
            return result;
        }

        protected DataTable QueryCommand()
        {
            SqlCommand sqlCommand = new SqlCommand(_query, Connection.Connection);
            if (_parameter != null)
            {
                sqlCommand.Parameters.AddRange(_parameter.ToArray());
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            try
            {
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                dataTable = new DataTable();
                throw e;
            }
            return dataTable;
        }

        protected int NonQueryCommand(bool transaction)
        {
            SqlCommand sqlCommand = Connection.Transaction != null ?
                new SqlCommand(_query, Connection.Connection, Connection.Transaction) :
                new SqlCommand(_query, Connection.Connection);
            if (_parameter != null)
            {
                sqlCommand.Parameters.AddRange(_parameter.ToArray());
            }
            int result;
            bool selfOpen = false;
            try
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    selfOpen = true;
                    Connection.Open(transaction);
                }
                result = sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (selfOpen)
                {
                    Connection.Close();
                }
            }
            return result;
        }

        protected List<T> QueryCommand<T>()
            where T : new()
        {
            SqlCommand sqlCommand = new SqlCommand(_query, Connection.Connection);
            if (_parameter != null)
            {
                sqlCommand.Parameters.AddRange(_parameter.ToArray());
            }

            // 返却リストを作成する
            List<T> result = new List<T>();
            bool selfOpen = false;
            try
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    selfOpen = true;
                    Connection.Open(false);
                }

                // クエリのスキーマを取得する
                using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                // プロパティとスキーマの定義を判定して一致するものを取得する
                List<ModelColumnSchema> types = CheckModelSchema.GetTrueSchema<T>(sqlDataReader.GetColumnSchema());

                // クエリを実行して一行取り出す
                while (sqlDataReader.Read())
                {
                    // 取り出した行をクラスに設定する
                    T t = new T();
                    foreach (ModelColumnSchema type in types)
                    {
                        var colValue = sqlDataReader[type.ColumnIndex];
                        type.ColumnInfo.SetValue(t, colValue == DBNull.Value ? null : colValue);
                    }
                    // 返却リストに追加する
                    result.Add(t);
                }
            }
            finally
            {
                if (selfOpen)
                {
                    Connection.Close();
                }
            }
            return result;
        }
    }
}
