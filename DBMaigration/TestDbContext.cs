using Microsoft.EntityFrameworkCore;

namespace DBMaigration
{
    public class TestDbContext : DbContext
    {
        /// <summary>
        /// マイグレーションするクラスをDbSetで定義する。
        /// </summary>
        public DbSet<Table1> Table1 { get; set; }

        /// <summary>
        /// DbContext継承クラスを作りOnConfiguringをオーバーライドするとマイグレーションが機能する。
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string server = "localhost\\SQLEXPRESS";
            string database = "TestDb";
            string user = "sa";
            string pass = "Express";

            _ = optionsBuilder.UseSqlServer("Persist Security Info=False;User ID=" + user + ";Password=" + pass + ";Initial Catalog=" + database + ";Server=" + server);
        }
    }
}

/*

① EntityFrameworkCoreのインストール
・Install-Package Microsoft.EntityFrameworkCore -Version 5.0.13
・Install-Package Microsoft.EntityFrameworkCore.Tools -Version 5.0.13

② DbContextクラスの作成
    public class AppDbContext : DbContext
    {
        public DbSet<Table1> Table1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            _ = optionsBuilder.UseSqlServer("Persist Security Info=False;User ID=sa;Password=Express;Initial Catalog=AppDb;Server=DESKTOP-II14AQP\\SQLEXPRESS");
        }
    }

③ マイグレーション開始
・Add-Migration AppDatabase　←　マイグレーションクラス名

④ DBServerに反映する
・Update-Database

⑤ マイグレーション更新
・Add-Migration AppDatabase2　←　新しいマイグレーションクラス名

⑥ 更新をDBServerに反映する
・Update-Database AppDatabase2

⑦ DBServerをロールバックする
・Update-Database AppDatabase

⑧ マイグレーションを初期化するにはMigrationsフォルダとデータベースを削除して③から始める

⑨ Add-Migration -context TestDbContext TestDatabase　←　コンテキストクラスを指定する
   Update-Database -context TestDbContext TestDatabase

 */
