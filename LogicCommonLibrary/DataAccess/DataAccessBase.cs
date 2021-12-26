using System;
using System.Collections.Generic;
using System.Text;

namespace LogicCommonLibrary.DataAccess
{
    public class DataAccessBase
    {
        private DatabaseConnection _connection;
        public DatabaseConnection Connection
        {
            get => _connection ??= new DatabaseConnection();
            set
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
                _connection = value;
            }
        }

        public void SelectCommand(string query)
        {

        }

        public void InsertCommand()
        {

        }

        public void DeleteCommand()
        {

        }
    }
}
