using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBMaigration.Migrations
{
    public partial class AppDatabase6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Optimist",
                table: "Table1",
                type: "DATETIME",
                maxLength: 8,
                nullable: false,
                defaultValue: 0x00);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Optimist",
                table: "Table1");
        }
    }
}
