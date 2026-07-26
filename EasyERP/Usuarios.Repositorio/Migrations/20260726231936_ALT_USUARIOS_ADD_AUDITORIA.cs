using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Usuarios.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class ALT_USUARIOS_ADD_AUDITORIA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AtualizadoEm",
                table: "USUARIOS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AtualizadoPor",
                table: "USUARIOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "USUARIOS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CriadoPor",
                table: "USUARIOS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deletado",
                table: "USUARIOS",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtualizadoEm",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "AtualizadoPor",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "CriadoPor",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "Deletado",
                table: "USUARIOS");
        }
    }
}
