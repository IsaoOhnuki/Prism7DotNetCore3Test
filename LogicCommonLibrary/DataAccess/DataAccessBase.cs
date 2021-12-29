using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

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

            // 変換するクラスのパブリックプロパティをすべて取得する
            List<Tuple<PropertyInfo, int>> types = GetPublicPropInfo<T>();

            // 返却リストを作成する
            List<T> result = new List<T>();
            try
            {
                Connection.Connection.Open();

                // クエリのスキーマを取得する
                using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                // プロパティとスキーマの定義を判定して一致するものを取得する
                types = CheckSchema(sqlDataReader.GetColumnSchema(), types);

                // クエリを実行して一行取り出す
                while (sqlDataReader.Read())
                {
                    // 取り出した行をクラスに設定する
                    T t = new T();
                    foreach (Tuple<PropertyInfo, int> type in types)
                    {
                        type.Item1.SetValue(t, sqlDataReader[type.Item2]);
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

        protected List<Tuple<PropertyInfo, int>> GetPublicPropInfo<T>()
            where T : new()
        {
            // 型を確定させてTypeを取得する
            Type typeT = new T().GetType();
            // すべてのパブリックプロパティを取得する。
            PropertyInfo[] props = typeT.GetProperties();
            // プロパティ型とカラムインデックスのリストを取得する。
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
            // プロパティ名をもとにDBのカラム型とプロパティ型を判定する。
            List<Tuple<PropertyInfo, int>> result = new List<Tuple<PropertyInfo, int>>();
            foreach (Tuple<PropertyInfo, int> type in types)
            {
                DbColumn col = schema.Where(x => x.ColumnName == type.Item1.Name).FirstOrDefault();
                if (col == null)
                {
                    // 同じDBカラム名が無ければパスする。
                    continue;
                }
                if (col.DataType != type.Item1.PropertyType)
                {
                    // 同じDBカラム型で無ければパスする。
                    continue;
                }
                if (!col.ColumnOrdinal.HasValue)
                {
                    // 同じDBカラムインデックスが無ければパスする。
                    continue;
                }
                var r = new Tuple<PropertyInfo, int>(type.Item1, col.ColumnOrdinal.Value);
                result.Add(r);
            }
            return result;
        }
    }
}
