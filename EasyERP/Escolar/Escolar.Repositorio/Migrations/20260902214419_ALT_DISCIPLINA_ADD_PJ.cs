using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escolar.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class ALT_DISCIPLINA_ADD_PJ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PessoaJuridicaId",
                schema: "Escolar",
                table: "Disciplinas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PessoaJuridicaId",
                schema: "Escolar",
                table: "Disciplinas");
        }
    }
}
