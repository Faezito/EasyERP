using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Usuarios.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class ALT_PESSOAS_DROPCOLUMN_USUARIOESENHA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PESSOAS_NomeUsuario",
                table: "PESSOAS");

            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "PESSOAS");

            migrationBuilder.DropColumn(
                name: "SenhaHash",
                table: "PESSOAS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "PESSOAS",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenhaHash",
                table: "PESSOAS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_NomeUsuario",
                table: "PESSOAS",
                column: "NomeUsuario",
                unique: true,
                filter: "[NomeUsuario] IS NOT NULL");
        }
    }
}
