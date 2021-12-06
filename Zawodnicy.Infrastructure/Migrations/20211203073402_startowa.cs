using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zawodnicy.Infrastructure.Migrations
{
    public partial class startowa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trener",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataUr = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trener", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zawodnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrenerId = table.Column<int>(type: "int", nullable: true),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kraj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataUr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Wzrost = table.Column<double>(type: "float", nullable: false),
                    Waga = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zawodnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zawodnik_Trener_TrenerId",
                        column: x => x.TrenerId,
                        principalTable: "Trener",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zawodnik_TrenerId",
                table: "Zawodnik",
                column: "TrenerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zawodnik");

            migrationBuilder.DropTable(
                name: "Trener");
        }
    }
}
