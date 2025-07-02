using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaApi.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCampoGenero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Libros");
        }
    }
}
