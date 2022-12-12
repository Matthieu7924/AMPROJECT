using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMPROJECT.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acteurs",
                columns: table => new
                {
                    ActeurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acteurs", x => x.ActeurId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieId);
                });

            migrationBuilder.CreateTable(
                name: "Panier",
                columns: table => new
                {
                    PanierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panier", x => x.PanierId);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: true),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSortie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prix = table.Column<float>(type: "real", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "CategorieId");
                });

            migrationBuilder.CreateTable(
                name: "FilmsActeurs",
                columns: table => new
                {
                    ActeursActeurId = table.Column<int>(type: "int", nullable: false),
                    FilmsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsActeurs", x => new { x.ActeursActeurId, x.FilmsId });
                    table.ForeignKey(
                        name: "FK_FilmsActeurs_Acteurs_ActeursActeurId",
                        column: x => x.ActeursActeurId,
                        principalTable: "Acteurs",
                        principalColumn: "ActeurId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmsActeurs_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmsPaniers",
                columns: table => new
                {
                    FilmPaniersId = table.Column<int>(type: "int", nullable: false),
                    PaniersPanierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsPaniers", x => new { x.FilmPaniersId, x.PaniersPanierId });
                    table.ForeignKey(
                        name: "FK_FilmsPaniers_Films_FilmPaniersId",
                        column: x => x.FilmPaniersId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmsPaniers_Panier_PaniersPanierId",
                        column: x => x.PaniersPanierId,
                        principalTable: "Panier",
                        principalColumn: "PanierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_CategorieId",
                table: "Films",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmsActeurs_FilmsId",
                table: "FilmsActeurs",
                column: "FilmsId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmsPaniers_PaniersPanierId",
                table: "FilmsPaniers",
                column: "PaniersPanierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmsActeurs");

            migrationBuilder.DropTable(
                name: "FilmsPaniers");

            migrationBuilder.DropTable(
                name: "Acteurs");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Panier");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
