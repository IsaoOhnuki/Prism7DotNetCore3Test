using System;
using System.Data.SqlClient;

namespace LogicCommonLibrary.DataAccess
{
    public class DatabaseConnection : IDisposable
    {
        public SqlConnection Connection { get; private set; }

        public SqlTransaction Transaction { get; private set; }

        public DatabaseConnection()
        {
        }

        public void Open(bool transaction)
        {
            if (Connection == null)
            {
                Connection = new SqlConnection();
            }
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
