using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyDanCu.Migrations
{
    /// <inheritdoc />
    public partial class addDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CanHos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DienTich = table.Column<double>(type: "float", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanHos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuDans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThuongTru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuDans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuDanCanHos",
                columns: table => new
                {
                    CuDanId = table.Column<int>(type: "int", nullable: false),
                    CanHoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuDanCanHos", x => new { x.CuDanId, x.CanHoId });
                    table.ForeignKey(
                        name: "FK_CuDanCanHos_CanHos_CanHoId",
                        column: x => x.CanHoId,
                        principalTable: "CanHos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuDanCanHos_CuDans_CuDanId",
                        column: x => x.CuDanId,
                        principalTable: "CuDans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuDanCanHos_CanHoId",
                table: "CuDanCanHos",
                column: "CanHoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuDanCanHos");

            migrationBuilder.DropTable(
                name: "CanHos");

            migrationBuilder.DropTable(
                name: "CuDans");
        }
    }
}
