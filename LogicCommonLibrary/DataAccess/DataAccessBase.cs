using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LogicCommonLibrary.DataAccess
{
    public class ScalarDataAccess : DataAccessBase
    {
        public ScalarDataAccess(DatabaseConnection connection, string query, SqlParameter[] parameter = null)
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
        public QueryDataAccess(DatabaseConnection connection, string query, SqlParameter[] parameter = null)
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
        public QueryDataAccess(DatabaseConnection connection, string query, SqlParameter[] parameter = null)
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
            object result;
            try
            {
                Connection.Connection.Open();
                result = sqlCommand.ExecuteScalar();
            }
            finally
            {
                Connection.Connection.Close();
            }
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

        protected int NonQueryCommand()
        {
            SqlCommand sqlCommand = Connection.Transaction != null ?
                new SqlCommand(_query, Connection.Connection, Connection.Transaction) :
                new SqlCommand(_query, Connection.Connection);
            if (_parameter != null)
            {
                sqlCommand.Parameters.AddRange(_parameter);
            }
            int result;
            try
            {
                Connection.Connection.Open();
                result = sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                Connection.Connection.Close();
            }
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

            // 返却リストを作成する
            List<T> result = new List<T>();
            try
            {
                Connection.Connection.Open();

                // クエリのスキーマを取得する
                using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                // プロパティとスキーマの定義を判定して一致するものを取得する
                List<ModelColumnSchema> types = new CheckModelSchema<T>().GetTrueSchema(sqlDataReader.GetColumnSchema());

                // クエリを実行して一行取り出す
                while (sqlDataReader.Read())
                {
                    // 取り出した行をクラスに設定する
                    T t = new T();
                    foreach (ModelColumnSchema type in types)
                    {
                        type.ColumnInfo.SetValue(t, sqlDataReader[type.ColumnIndex]);
                    }
                    // 返却リストに追加する
                    result.Add(t);
                }
            }
            finally
            {
                Connection.Connection.Close();
            }
            return result;
        }
    }
}
