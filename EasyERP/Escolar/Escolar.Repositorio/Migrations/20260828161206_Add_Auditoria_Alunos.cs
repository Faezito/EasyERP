using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escolar.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class Add_Auditoria_Alunos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AtualizadoEm",
                schema: "Escolar",
                table: "Alunos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AtualizadoPor",
                schema: "Escolar",
                table: "Alunos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                schema: "Escolar",
                table: "Alunos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CriadoPor",
                schema: "Escolar",
                table: "Alunos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deletado",
                schema: "Escolar",
                table: "Alunos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtualizadoEm",
                schema: "Escolar",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "AtualizadoPor",
                schema: "Escolar",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                schema: "Escolar",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "CriadoPor",
                schema: "Escolar",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Deletado",
                schema: "Escolar",
                table: "Alunos");
        }
    }
}
