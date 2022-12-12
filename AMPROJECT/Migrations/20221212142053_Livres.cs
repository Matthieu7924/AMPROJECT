using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMPROJECT.Migrations
{
    /// <inheritdoc />
    public partial class Livres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auteurs",
                columns: table => new
                {
                    AuteurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biographie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteurs", x => x.AuteurId);
                });

            migrationBuilder.CreateTable(
                name: "Livres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livres_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "CategorieId");
                });

            migrationBuilder.CreateTable(
                name: "LivrePanier",
                columns: table => new
                {
                    LivrePaniersId = table.Column<int>(type: "int", nullable: false),
                    PaniersPanierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivrePanier", x => new { x.LivrePaniersId, x.PaniersPanierId });
                    table.ForeignKey(
                        name: "FK_LivrePanier_Livres_LivrePaniersId",
                        column: x => x.LivrePaniersId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivrePanier_Panier_PaniersPanierId",
                        column: x => x.PaniersPanierId,
                        principalTable: "Panier",
                        principalColumn: "PanierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivresAuteurs",
                columns: table => new
                {
                    AuteursAuteurId = table.Column<int>(type: "int", nullable: false),
                    LivresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivresAuteurs", x => new { x.AuteursAuteurId, x.LivresId });
                    table.ForeignKey(
                        name: "FK_LivresAuteurs_Auteurs_AuteursAuteurId",
                        column: x => x.AuteursAuteurId,
                        principalTable: "Auteurs",
                        principalColumn: "AuteurId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivresAuteurs_Livres_LivresId",
                        column: x => x.LivresId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivrePanier_PaniersPanierId",
                table: "LivrePanier",
                column: "PaniersPanierId");

            migrationBuilder.CreateIndex(
                name: "IX_Livres_CategorieId",
                table: "Livres",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_LivresAuteurs_LivresId",
                table: "LivresAuteurs",
                column: "LivresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivrePanier");

            migrationBuilder.DropTable(
                name: "LivresAuteurs");

            migrationBuilder.DropTable(
                name: "Auteurs");

            migrationBuilder.DropTable(
                name: "Livres");
        }
    }
}
