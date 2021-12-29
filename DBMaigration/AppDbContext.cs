using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBMaigration
{
    public class AppDbContext : DbContext
    {
        public DbSet<Table1> Table1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            _ = optionsBuilder.UseSqlServer("Persist Security Info=False;User ID=sa;Password=Express;Initial Catalog=AppDb;Server=DESKTOP-II14AQP\\SQLEXPRESS");
        }
    }
}
