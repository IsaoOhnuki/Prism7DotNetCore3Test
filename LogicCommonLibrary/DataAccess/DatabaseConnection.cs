using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LogicCommonLibrary.DataAccess
{
    public class DatabaseConnection : IDisposable
    {
        public SqlConnection Connection { get; private set; }

        public SqlTransaction Transaction { get; private set; }

        public DatabaseConnection()
        {

        }

        public void Open()
        {
            if (Connection == null)
            {
                Connection = new SqlConnection();
            }
            Connection.Open();
        }

        public void Close()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction = null;
            }
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
