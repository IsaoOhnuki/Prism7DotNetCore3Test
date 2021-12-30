using DBMaigration;
using LogicCommonLibrary.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace TestProject.Logic.LogicCommonLibrary.DataAccess
{
    [TestClass]
    public class TestGetCommandQueryT
    {
        [TestMethod]
        public void GetInsertQuery01()
        {
            string server = "localhost\\SQLEXPRESS";
            string database = "AppDb";
            string user = "sa";
            string pass = "Express";
            string conn = "Persist Security Info=False;User ID=" + user + ";Password=" + pass + ";Initial Catalog=" + database + ";Server=" + server;
            using DatabaseConnection connection = new DatabaseConnection(conn);

            try
            {
                string deleteQuery = "DELETE FROM Table1;";
                NonQueryDataAccess deleteDataAccess = new NonQueryDataAccess(connection, deleteQuery, null);
                deleteDataAccess.DoNonQuery();

                GetCommandQuery<Table1>.GetInsertQuery(out string updateQuery, out List<SqlParameter> sqlParameters);
                Table1 table1 = new Table1
                {
                    Name = "abc",
                    Phone = "",
                    Sex = "",
                    Age = 5,
                };
                NonQueryDataAccess insertDataAccess =
                    new NonQueryDataAccess(connection, updateQuery, GetCommandQuery<Table1>.GetQueryParameter(sqlParameters, table1));
                insertDataAccess.DoNonQuery();

                string countQuery = "SELECT COUNT(ID) FROM Table1;";
                ScalarDataAccess scalardataAccess = new ScalarDataAccess(connection, countQuery, null);
                int? count = scalardataAccess.GetScalar() as int?;
                Assert.IsTrue(count.Value == 1);

                string selectQuery = "SELECT * FROM Table1;";
                QueryDataAccess<Table1> selectDataAccess = new QueryDataAccess<Table1>(connection, selectQuery, null);
                List<Table1> rows = selectDataAccess.DoQuery();
                Assert.IsTrue(rows[0].Name == "abc");

                rows[0].Name = "def";
                GetCommandQuery<Table1>.GetUpdateQuery(out updateQuery, out sqlParameters);
                NonQueryDataAccess updateDataAccess =
                    new NonQueryDataAccess(connection, updateQuery, GetCommandQuery<Table1>.GetQueryParameter(sqlParameters, rows[0]));
                int successCount = updateDataAccess.DoNonQuery();
                Assert.IsTrue(successCount == 1);
                string lastQuery = DataAccessBase.LastQuery;
                string lastQueryParam = DataAccessBase.LastQueryParam;

                selectQuery = "SELECT * FROM Table1;";
                selectDataAccess = new QueryDataAccess<Table1>(connection, selectQuery, null);
                rows = selectDataAccess.DoQuery();
                Assert.IsTrue(rows[0].Name == "def");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void GetInsertQuery02()
        {
            string server = "localhost\\SQLEXPRESS";
            string database = "AppDb";
            string user = "sa";
            string pass = "Express";
            string conn = "Persist Security Info=False;User ID=" + user + ";Password=" + pass + ";Initial Catalog=" + database + ";Server=" + server;
            using DatabaseConnection connection = new DatabaseConnection(conn);

            try
            {
                string deleteQuery = "DELETE FROM Table1;";
                NonQueryDataAccess deleteDataAccess = new NonQueryDataAccess(connection, deleteQuery, null);
                deleteDataAccess.DoNonQuery();

                GetCommandQuery<Table1>.GetInsertQuery(out string updateQuery, out List<SqlParameter> sqlParameters);
                Table1 table1 = new Table1
                {
                    Name = "abc",
                    Phone = "",
                    Sex = "",
                    Age = 5,
                };
                NonQueryDataAccess insertDataAccess =
                    new NonQueryDataAccess(connection, updateQuery, GetCommandQuery<Table1>.GetQueryParameter(sqlParameters, table1));
                insertDataAccess.DoNonQuery();

                string countQuery = "SELECT COUNT(ID) FROM Table1;";
                ScalarDataAccess scalardataAccess = new ScalarDataAccess(connection, countQuery, null);
                int? count = scalardataAccess.GetScalar() as int?;
                Assert.IsTrue(count.Value == 1);

                string selectQuery = "SELECT * FROM Table1;";
                QueryDataAccess<Table1> selectDataAccess = new QueryDataAccess<Table1>(connection, selectQuery, null);
                List<Table1> rows = selectDataAccess.DoQuery();
                Assert.IsTrue(rows[0].Name == "abc");

                GetCommandQuery<Table1>.GetDeleteQuery(out deleteQuery, out sqlParameters);
                deleteDataAccess =
                    new NonQueryDataAccess(connection, deleteQuery, GetCommandQuery<Table1>.GetQueryParameter(sqlParameters, rows[0]));
                int successCount = deleteDataAccess.DoNonQuery();
                Assert.IsTrue(successCount == 1);
                string lastQuery = DataAccessBase.LastQuery;
                string lastQueryParam = DataAccessBase.LastQueryParam;

                selectQuery = "SELECT * FROM Table1;";
                selectDataAccess = new QueryDataAccess<Table1>(connection, selectQuery, null);
                rows = selectDataAccess.DoQuery();
                Assert.IsTrue(rows.Count == 0);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
