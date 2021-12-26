using Dapper;
using ModelLibrary.Services;
using System.Data;
using System.Data.SqlClient;

namespace ApplicationLogicModule
{
    public class Table_1
    {
        public string col_1 { get; set; }
        public int col_2 { get; set; }
        public byte[] col_3 { get; set; }
    }

    public class ApplicationLogic : IApplicationLogic
    {
        public ILogService Logger { get; set; }

        public ApplicationLogic(ILogService logger)
        {
            Logger = logger;
        }

        public void Read()
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                // 接続文字列
                connection.ConnectionString = @"Data Source=desktop-ii14aqp\sqlexpress1;Initial Catalog=Example;User Id=sa;Password=Express;";

                // 接続
                connection.Open();

                // クエリ
                var query = "SELECT * FROM dbo.Table_1";

                // SQLの発行とデータのマッピング
                // 取得データは IEnumerable<Person> 型
                var result = connection.Query<Table_1>(query);
            }
        }
    }
}
