using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class ALT_MODULOS_ADD_IMAGEM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Modulo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Modulo");
        }
    }
}
