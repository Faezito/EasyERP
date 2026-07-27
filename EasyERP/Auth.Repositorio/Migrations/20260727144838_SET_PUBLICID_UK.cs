using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class SET_PUBLICID_UK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_PublicId",
                table: "USUARIOS",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PESSOASJURIDICAS_PublicId",
                table: "PESSOASJURIDICAS",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_PublicId",
                table: "PESSOAS",
                column: "PublicId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_PublicId",
                table: "USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_PESSOASJURIDICAS_PublicId",
                table: "PESSOASJURIDICAS");

            migrationBuilder.DropIndex(
                name: "IX_PESSOAS_PublicId",
                table: "PESSOAS");
        }
    }
}
