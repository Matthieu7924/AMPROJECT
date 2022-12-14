using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMPROJECT.Migrations
{
    /// <inheritdoc />
    public partial class MAJPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Livres");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Films");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Films");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Livres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
