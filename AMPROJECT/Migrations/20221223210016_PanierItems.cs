using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMPROJECT.Migrations
{
    /// <inheritdoc />
    public partial class PanierItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PanierItems",
                columns: table => new
                {
                    PanierItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmsId = table.Column<int>(type: "int", nullable: true),
                    Quantites = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanierItems", x => x.PanierItemId);
                    table.ForeignKey(
                        name: "FK_PanierItems_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "ccce8e7d-61c3-4176-86eb-bf85c4aa416e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "80a15c6e-049f-40fc-b0fb-cd5d976c3028");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4d2093e1-b338-4d6b-8cbe-ff52202cc203", "AQAAAAEAACcQAAAAEE03QARRZ7hqRB4iQQMa03haFQALW1M3GC7hdOJxH1AZzFpP7d6RVy9+5FsNQ0k6kQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_PanierItems_FilmsId",
                table: "PanierItems",
                column: "FilmsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PanierItems");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "45b76395-e65a-418e-8405-17a01eb23717");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "780b4fff-6c5b-4bc2-8e57-263b7d5b95bd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "05de400e-3bfe-47f0-bc97-436c0ed46a90", "AQAAAAEAACcQAAAAEKkmeyYsp9In3aHLikClYGVIMPbw8gvyNoVYNnBJUplDGwduZMS5YMzU+th4vBGLHQ==" });
        }
    }
}
