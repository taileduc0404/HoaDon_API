using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoaDon_API.Migrations
{
    public partial class setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hanghoa",
                columns: table => new
                {
                    mahang = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    tenhang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dvt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dongia = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hanghoa", x => x.mahang);
                });

            migrationBuilder.CreateTable(
                name: "hoadon",
                columns: table => new
                {
                    sohd = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ngaylaphd = table.Column<DateTime>(type: "datetime", nullable: true),
                    tenkh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoadon", x => x.sohd);
                });

            migrationBuilder.CreateTable(
                name: "chitiethoadon",
                columns: table => new
                {
                    sohd = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    mahang = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    dongia = table.Column<double>(type: "float", nullable: true),
                    soluong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chitiethoadon", x => new { x.sohd, x.mahang });
                    table.ForeignKey(
                        name: "FK_chitiethoadon_hanghoa",
                        column: x => x.mahang,
                        principalTable: "hanghoa",
                        principalColumn: "mahang");
                    table.ForeignKey(
                        name: "FK_chitiethoadon_hoadon",
                        column: x => x.sohd,
                        principalTable: "hoadon",
                        principalColumn: "sohd");
                });

            migrationBuilder.CreateIndex(
                name: "IX_chitiethoadon_mahang",
                table: "chitiethoadon",
                column: "mahang");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chitiethoadon");

            migrationBuilder.DropTable(
                name: "hanghoa");

            migrationBuilder.DropTable(
                name: "hoadon");
        }
    }
}
