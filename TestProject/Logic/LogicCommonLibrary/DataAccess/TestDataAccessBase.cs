using DBMaigration;
using LogicCommonLibrary.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TestProject.Logic.LogicCommonLibrary.DataAccess
{
    [TestClass]
    public class TestDataAccessBase
    {
        [TestMethod]
        public void QueryDataAccessT()
        {
            string server = "localhost\\SQLEXPRESS";
            string database = "AppDb";
            string user = "sa";
            string pass = "Express";
            string conn = "Persist Security Info=False;User ID=" + user + ";Password=" + pass + ";Initial Catalog=" + database + ";Server=" + server;

            try
            {
                using DatabaseConnection connection = new DatabaseConnection(conn);

                string deleteQuery = "DELETE FROM Table1;";
                NonQueryDataAccess deleteDataAccess = new NonQueryDataAccess(connection, deleteQuery, null);
                deleteDataAccess.DoNonQuery();

                string insertQuery = "INSERT INTO Table1 (Name,Sex,Phone,Optimist) VALUES('abc','','',GetDate());";
                NonQueryDataAccess insertDataAccess = new NonQueryDataAccess(connection, insertQuery, null);
                insertDataAccess.DoNonQuery();

                string countQuery = "SELECT COUNT(ID) FROM Table1;";
                ScalarDataAccess scalardataAccess = new ScalarDataAccess(connection, countQuery, null);
                int? count = scalardataAccess.GetScalar() as int?;
                Assert.IsTrue(count.Value == 1);

                string selectQuery = "SELECT * FROM Table1;";
                QueryDataAccess<Table1> selectDataAccess = new QueryDataAccess<Table1>(connection, selectQuery, null);
                List<Table1> rows = selectDataAccess.DoQuery();
                Assert.IsTrue(rows[0].Name == "abc");

                insertQuery = "INSERT INTO Table1 (Name,Sex,Phone,Optimist) VALUES('abc','','',GetDate());";
                insertDataAccess = new NonQueryDataAccess(connection, insertQuery, null);
                insertDataAccess.DoNonQuery();

                countQuery = "SELECT COUNT(ID) FROM Table1;";
                scalardataAccess = new ScalarDataAccess(connection, countQuery, null);
                count = scalardataAccess.GetScalar() as int?;
                Assert.IsTrue(count.Value == 2);

                selectQuery = "SELECT * FROM Table1;";
                selectDataAccess = new QueryDataAccess<Table1>(connection, selectQuery, null);
                rows = selectDataAccess.DoQuery();
                Assert.IsTrue(rows.Count == 2);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void QueryDataAccess()
        {
            string server = "localhost\\SQLEXPRESS";
            string database = "AppDb";
            string user = "sa";
            string pass = "Express";
            string conn = "Persist Security Info=False;User ID=" + user + ";Password=" + pass + ";Initial Catalog=" + database + ";Server=" + server;

            try
            {
                DatabaseConnection connection = new DatabaseConnection(conn);

                string deleteQuery = "DELETE FROM Table1;";
                NonQueryDataAccess deleteDataAccess = new NonQueryDataAccess(connection, deleteQuery, null);
                deleteDataAccess.DoNonQuery();

                string insertQuery = "INSERT INTO Table1 (Name,Sex,Phone,Optimist) VALUES('abc','','',GetDate());";
                NonQueryDataAccess insertDataAccess = new NonQueryDataAccess(connection, insertQuery, null);
                insertDataAccess.DoNonQuery();

                string countQuery = "SELECT COUNT(ID) FROM Table1;";
                ScalarDataAccess scalardataAccess = new ScalarDataAccess(connection, countQuery, null);
                int? count = scalardataAccess.GetScalar() as int?;
                Assert.IsTrue(count.Value == 1);

                string selectQuery = "SELECT * FROM Table1;";
                QueryDataAccess selectDataAccess = new QueryDataAccess(connection, selectQuery, null);
                DataTable rows = selectDataAccess.DoQuery();
                Assert.IsTrue(rows.Rows[0]["Name"] as string == "abc");

                insertQuery = "INSERT INTO Table1 (Name,Sex,Phone,Optimist) VALUES('abc','','',GetDate());";
                insertDataAccess = new NonQueryDataAccess(connection, insertQuery, null);
                insertDataAccess.DoNonQuery();

                countQuery = "SELECT COUNT(ID) FROM Table1;";
                scalardataAccess = new ScalarDataAccess(connection, countQuery, null);
                count = scalardataAccess.GetScalar() as int?;
                Assert.IsTrue(count.Value == 2);

                selectQuery = "SELECT * FROM Table1;";
                selectDataAccess = new QueryDataAccess(connection, selectQuery, null);
                rows = selectDataAccess.DoQuery();
                Assert.IsTrue(rows.Rows.Count == 2);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
