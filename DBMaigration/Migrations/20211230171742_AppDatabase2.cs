using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBMaigration.Migrations
{
    public partial class AppDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Byte",
                table: "Table1",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte[]>(
                name: "ByteArray",
                table: "Table1",
                type: "varbinary(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Decimal",
                table: "Table1",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "Long",
                table: "Table1",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Byte",
                table: "Table1");

            migrationBuilder.DropColumn(
                name: "ByteArray",
                table: "Table1");

            migrationBuilder.DropColumn(
                name: "Decimal",
                table: "Table1");

            migrationBuilder.DropColumn(
                name: "Long",
                table: "Table1");
        }
    }
}
