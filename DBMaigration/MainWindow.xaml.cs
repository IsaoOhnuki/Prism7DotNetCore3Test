using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DBMaigration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}

/*

① EntityFrameworkCoreのインストール
・Install-Package Microsoft.EntityFrameworkCore -Version 5.0.13

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
・Update-Database AppDatabase2

⑧ マイグレーションを初期化するにはMigrationsフォルダとデータベースを削除して③から始める

 */
