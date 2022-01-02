using ModelLibrary.Services;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LogicCommonLibrary.DataAccess
{
    public class DatabaseConnection : IDatabaseConnection, IDisposable
    {
        private readonly string _connectionString;
        private readonly SqlCredential _credential;

        public SqlConnection Connection { get; private set; }

        public SqlCredential Credential { get; private set; }

        public SqlTransaction Transaction { get; private set; }

        public ConnectionState State => Connection != null ? Connection.State : ConnectionState.Broken;

        public DatabaseConnection(string connectionString)
        {
            _connectionString = connectionString;
            Connection = new SqlConnection(_connectionString);
        }

        public DatabaseConnection(string connectionString, SqlCredential credential)
        {
            _connectionString = connectionString;
            _credential = credential;
            Connection = new SqlConnection(_connectionString, _credential);
        }

        public void Open(bool transaction = false)
        {
            Connection.Open();
            if (transaction)
            {
                Transaction = Connection.BeginTransaction();
            }
        }

        public void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction = null;
            }
        }

        public void Rollback()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
                Transaction = null;
            }
        }

        public void Close()
        {
            Commit();
            if (Connection != null)
            {
                Connection.Close();
            }
        }

        public void Dispose()
        {
            Close();
        }
    }
}
