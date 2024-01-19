using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Creation_de_personnage.Migrations
{
    public partial class NoyelleGodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personnages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pseudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointDeVie = table.Column<int>(type: "int", nullable: true),
                    Armure = table.Column<int>(type: "int", nullable: true),
                    Degats = table.Column<int>(type: "int", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreVictime = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Personnages",
                columns: new[] { "Id", "Armure", "DateCreation", "Degats", "NombreVictime", "PointDeVie", "Pseudo" },
                values: new object[] { 1, 4, new DateTime(2024, 1, 19, 10, 2, 27, 945, DateTimeKind.Local).AddTicks(7560), 6, 0, 12, "AlexHam" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personnages");
        }
    }
}
