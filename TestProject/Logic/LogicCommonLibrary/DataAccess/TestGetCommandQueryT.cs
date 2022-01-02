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
            string database = "TestDb";
            string user = "sa";
            string pass = "Express";
            string conn = "Persist Security Info=False;User ID=" + user + ";Password=" + pass + ";Initial Catalog=" + database + ";Server=" + server;

            try
            {
                using DatabaseConnection connection = new DatabaseConnection();
                connection.SetConnection(conn);

                string deleteQuery = "DELETE FROM Table1;";
                NonQueryDataAccess deleteDataAccess = new NonQueryDataAccess(connection, deleteQuery, null);
                deleteDataAccess.DoNonQuery(false);

                GetCommandQuery<Table1>.GetInsertQuery(out string updateQuery, out List<SqlParameter> sqlParameters);
                Table1 table1 = new Table1
                {
                    Name = "abc",
                    Phone = "",
                    Sex = "",
                    Age = 5,
                };
                NonQueryDataAccess insertDataAccess =
                    new NonQueryDataAccess(connection, updateQuery,
                        GetCommandQuery<Table1>.GetQueryParameter(sqlParameters,
                            CheckModelSchema.GetModelSchema<Table1>(connection.Connection), table1));
                insertDataAccess.DoNonQuery(false);

                string countQuery = "SELECT COUNT(*) FROM Table1;";
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
                    new NonQueryDataAccess(connection, updateQuery,
                        GetCommandQuery<Table1>.GetQueryParameter(sqlParameters,
                            CheckModelSchema.GetModelSchema<Table1>(connection.Connection), rows[0]));
                int successCount = updateDataAccess.DoNonQuery(false);
                Assert.IsTrue(successCount == 1);

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
            string database = "TestDb";
            string user = "sa";
            string pass = "Express";
            string conn = "Persist Security Info=False;User ID=" + user + ";Password=" + pass + ";Initial Catalog=" + database + ";Server=" + server;

            try
            {
                using DatabaseConnection connection = new DatabaseConnection();
                connection.SetConnection(conn);

                string deleteQuery = "DELETE FROM Table1;";
                NonQueryDataAccess deleteDataAccess = new NonQueryDataAccess(connection, deleteQuery, null);
                deleteDataAccess.DoNonQuery(false);

                GetCommandQuery<Table1>.GetInsertQuery(out string updateQuery, out List<SqlParameter> sqlParameters);
                Table1 table1 = new Table1
                {
                    Name = "abc",
                    Phone = "",
                    Sex = "",
                    Age = 5,
                };
                NonQueryDataAccess insertDataAccess =
                    new NonQueryDataAccess(connection, updateQuery,
                        GetCommandQuery<Table1>.GetQueryParameter(sqlParameters,
                            CheckModelSchema.GetModelSchema<Table1>(connection.Connection), table1));
                insertDataAccess.DoNonQuery(false);

                string countQuery = "SELECT COUNT(*) FROM Table1;";
                ScalarDataAccess scalardataAccess = new ScalarDataAccess(connection, countQuery, null);
                int? count = scalardataAccess.GetScalar() as int?;
                Assert.IsTrue(count.Value == 1);

                string selectQuery = "SELECT * FROM Table1;";
                QueryDataAccess<Table1> selectDataAccess = new QueryDataAccess<Table1>(connection, selectQuery, null);
                List<Table1> rows = selectDataAccess.DoQuery();
                Assert.IsTrue(rows[0].Name == "abc");

                GetCommandQuery<Table1>.GetDeleteQuery(out deleteQuery, out sqlParameters);
                deleteDataAccess =
                    new NonQueryDataAccess(connection, deleteQuery,
                        GetCommandQuery<Table1>.GetQueryParameter(sqlParameters,
                            CheckModelSchema.GetModelSchema<Table1>(connection.Connection), rows[0]));
                int successCount = deleteDataAccess.DoNonQuery(false);
                Assert.IsTrue(successCount == 1);

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

        [TestMethod]
        public void GetInsertQuery03()
        {
            string server = "localhost\\SQLEXPRESS";
            string database = "TestDb";
            string user = "sa";
            string pass = "Express";
            string conn = "Persist Security Info=False;User ID=" + user + ";Password=" + pass + ";Initial Catalog=" + database + ";Server=" + server;

            try
            {
                using DatabaseConnection connection = new DatabaseConnection();
                connection.SetConnection(conn);

                string deleteQuery = "DELETE FROM Table2;";
                NonQueryDataAccess deleteDataAccess = new NonQueryDataAccess(connection, deleteQuery, null);
                deleteDataAccess.DoNonQuery(false);

                GetCommandQuery<Table2>.GetInsertQuery(out string updateQuery, out List<SqlParameter> sqlParameters);
                Table2 table2 = new Table2
                {
                    Name = "abc",
                };
                NonQueryDataAccess insertDataAccess =
                    new NonQueryDataAccess(connection, updateQuery,
                        GetCommandQuery<Table2>.GetQueryParameter(sqlParameters,
                            CheckModelSchema.GetModelSchema<Table2>(connection.Connection), table2));
                insertDataAccess.DoNonQuery(false);

                string countQuery = "SELECT COUNT(*) FROM Table2;";
                ScalarDataAccess scalardataAccess = new ScalarDataAccess(connection, countQuery, null);
                int? count = scalardataAccess.GetScalar() as int?;
                Assert.IsTrue(count.Value == 1);

                string selectQuery = "SELECT * FROM Table2;";
                QueryDataAccess<Table2> selectDataAccess = new QueryDataAccess<Table2>(connection, selectQuery, null);
                List<Table2> rows = selectDataAccess.DoQuery();
                Assert.IsTrue(rows[0].Name == "abc");

                rows[0].Name = "def";
                GetCommandQuery<Table2>.GetUpdateQuery(out updateQuery, out sqlParameters);
                NonQueryDataAccess updateDataAccess =
                    new NonQueryDataAccess(connection, updateQuery,
                        GetCommandQuery<Table2>.GetQueryParameter(sqlParameters,
                            CheckModelSchema.GetModelSchema<Table2>(connection.Connection), rows[0]));
                int successCount = updateDataAccess.DoNonQuery(false);
                Assert.IsTrue(successCount == 1);

                selectQuery = "SELECT * FROM Table2;";
                selectDataAccess = new QueryDataAccess<Table2>(connection, selectQuery, null);
                rows = selectDataAccess.DoQuery();
                Assert.IsTrue(rows[0].Name == "def");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void GetInsertQuery04()
        {
            string server = "localhost\\SQLEXPRESS";
            string database = "TestDb";
            string user = "sa";
            string pass = "Express";
            string conn = "Persist Security Info=False;User ID=" + user + ";Password=" + pass + ";Initial Catalog=" + database + ";Server=" + server;

            try
            {
                using DatabaseConnection connection = new DatabaseConnection();
                connection.SetConnection(conn);

                string deleteQuery = "DELETE FROM Table2;";
                NonQueryDataAccess deleteDataAccess = new NonQueryDataAccess(connection, deleteQuery, null);
                deleteDataAccess.DoNonQuery(false);

                GetCommandQuery<Table2>.GetInsertQuery(out string updateQuery, out List<SqlParameter> sqlParameters);
                Table2 table2 = new Table2
                {
                    Name = "abc",
                };
                NonQueryDataAccess insertDataAccess =
                    new NonQueryDataAccess(connection, updateQuery,
                        GetCommandQuery<Table2>.GetQueryParameter(sqlParameters,
                            CheckModelSchema.GetModelSchema<Table2>(connection.Connection), table2));
                insertDataAccess.DoNonQuery(false);

                string countQuery = "SELECT COUNT(*) FROM Table2;";
                ScalarDataAccess scalardataAccess = new ScalarDataAccess(connection, countQuery, null);
                int? count = scalardataAccess.GetScalar() as int?;
                Assert.IsTrue(count.Value == 1);

                string selectQuery = "SELECT * FROM Table2;";
                QueryDataAccess<Table2> selectDataAccess = new QueryDataAccess<Table2>(connection, selectQuery, null);
                List<Table2> rows = selectDataAccess.DoQuery();
                Assert.IsTrue(rows[0].Name == "abc");

                GetCommandQuery<Table2>.GetDeleteQuery(out deleteQuery, out sqlParameters);
                deleteDataAccess =
                    new NonQueryDataAccess(connection, deleteQuery,
                        GetCommandQuery<Table2>.GetQueryParameter(sqlParameters,
                            CheckModelSchema.GetModelSchema<Table2>(connection.Connection), rows[0]));
                int successCount = deleteDataAccess.DoNonQuery(false);
                Assert.IsTrue(successCount == 1);

                selectQuery = "SELECT * FROM Table2;";
                selectDataAccess = new QueryDataAccess<Table2>(connection, selectQuery, null);
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
