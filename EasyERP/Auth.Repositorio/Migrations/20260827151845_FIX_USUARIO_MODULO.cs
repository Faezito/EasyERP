using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class FIX_USUARIO_MODULO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioModulo_EmpresaModulo_EmpresaModuloId",
                table: "UsuarioModulo");

            migrationBuilder.DropTable(
                name: "EmpresaModulo");

            migrationBuilder.RenameColumn(
                name: "EmpresaModuloId",
                table: "UsuarioModulo",
                newName: "ModuloId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioModulo_UsuarioId_EmpresaModuloId",
                table: "UsuarioModulo",
                newName: "IX_UsuarioModulo_UsuarioId_ModuloId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioModulo_EmpresaModuloId",
                table: "UsuarioModulo",
                newName: "IX_UsuarioModulo_ModuloId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "USUARIOS",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "UsuarioModulo",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "UsuarioEmpresa",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "PESSOASJURIDICAS",
                type: "smalldatetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "PESSOAS",
                type: "smalldatetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioModulo_Modulo_ModuloId",
                table: "UsuarioModulo",
                column: "ModuloId",
                principalTable: "Modulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioModulo_Modulo_ModuloId",
                table: "UsuarioModulo");

            migrationBuilder.RenameColumn(
                name: "ModuloId",
                table: "UsuarioModulo",
                newName: "EmpresaModuloId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioModulo_UsuarioId_ModuloId",
                table: "UsuarioModulo",
                newName: "IX_UsuarioModulo_UsuarioId_EmpresaModuloId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioModulo_ModuloId",
                table: "UsuarioModulo",
                newName: "IX_UsuarioModulo_EmpresaModuloId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "USUARIOS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "UsuarioModulo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "UsuarioEmpresa",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "PESSOASJURIDICAS",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "PESSOAS",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EmpresaModulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuloId = table.Column<int>(type: "int", nullable: false),
                    PessoaJuridicaId = table.Column<int>(type: "int", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaModulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpresaModulo_Modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaModulo_PESSOASJURIDICAS_PessoaJuridicaId",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "PESSOASJURIDICAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaModulo_ModuloId",
                table: "EmpresaModulo",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaModulo_PessoaJuridicaId",
                table: "EmpresaModulo",
                column: "PessoaJuridicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioModulo_EmpresaModulo_EmpresaModuloId",
                table: "UsuarioModulo",
                column: "EmpresaModuloId",
                principalTable: "EmpresaModulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
