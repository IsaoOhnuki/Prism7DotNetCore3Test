using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBMaigration.Migrations.AppDb
{
    public partial class AppDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MProduct",
                columns: table => new
                {
                    MProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductShortName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductMemo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProductPriceType = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Optimist = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MProduct", x => x.MProductId);
                });

            migrationBuilder.CreateTable(
                name: "TCustomer",
                columns: table => new
                {
                    TCustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CustomerMemo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerMemo1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Optimist = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCustomer", x => x.TCustomerId);
                });

            migrationBuilder.CreateTable(
                name: "TProduct",
                columns: table => new
                {
                    TProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TReserveId = table.Column<int>(type: "int", nullable: false),
                    MProductId = table.Column<int>(type: "int", nullable: false),
                    ProductShortName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductMemo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProductPriceType = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Optimist = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProduct", x => x.TProductId);
                });

            migrationBuilder.CreateTable(
                name: "TReserve",
                columns: table => new
                {
                    ReserveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(type: "int", nullable: false),
                    BlockStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BlockEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReserveStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReserveEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReserveMemo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReserveMemo1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Optimist = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TReserve", x => x.ReserveId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MProduct");

            migrationBuilder.DropTable(
                name: "TCustomer");

            migrationBuilder.DropTable(
                name: "TProduct");

            migrationBuilder.DropTable(
                name: "TReserve");
        }
    }
}
