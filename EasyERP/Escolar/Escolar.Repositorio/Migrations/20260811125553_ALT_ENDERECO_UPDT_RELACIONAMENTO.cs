using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escolar.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class ALT_ENDERECO_UPDT_RELACIONAMENTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Pessoas_PessoaId1",
                schema: "Escolar",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_PessoaId1",
                schema: "Escolar",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "PessoaId1",
                schema: "Escolar",
                table: "Enderecos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                schema: "Escolar",
                table: "Turmas",
                type: "smalldatetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                schema: "Escolar",
                table: "Presencas",
                type: "smalldatetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                schema: "Escolar",
                table: "Pessoas",
                type: "smalldatetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                schema: "Escolar",
                table: "Notas",
                type: "smalldatetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                schema: "Escolar",
                table: "Disciplinas",
                type: "smalldatetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                schema: "Escolar",
                table: "AlunosResponsaveis",
                type: "smalldatetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                schema: "Escolar",
                table: "Turmas",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                schema: "Escolar",
                table: "Presencas",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                schema: "Escolar",
                table: "Pessoas",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                schema: "Escolar",
                table: "Notas",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PessoaId1",
                schema: "Escolar",
                table: "Enderecos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                schema: "Escolar",
                table: "Disciplinas",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                schema: "Escolar",
                table: "AlunosResponsaveis",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PessoaId1",
                schema: "Escolar",
                table: "Enderecos",
                column: "PessoaId1",
                unique: true,
                filter: "[PessoaId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Pessoas_PessoaId1",
                schema: "Escolar",
                table: "Enderecos",
                column: "PessoaId1",
                principalSchema: "Escolar",
                principalTable: "Pessoas",
                principalColumn: "Id");
        }
    }
}
