﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBMaigration.Migrations
{
    public partial class TestDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Table1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Optimist = table.Column<DateTime>(type: "datetime2", maxLength: 8, nullable: false),
                    Decimal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Long = table.Column<long>(type: "bigint", nullable: false),
                    Byte = table.Column<byte>(type: "tinyint", nullable: false),
                    ByteArray = table.Column<byte[]>(type: "varbinary(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table1", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Table1");
        }
    }
}