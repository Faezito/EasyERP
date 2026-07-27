using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class Migracaoinicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "PessoaBaseSequence");

            migrationBuilder.CreateTable(
                name: "ENDERECOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    BaseUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealthCheckPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VersaoApi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaModulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaJuridicaId = table.Column<int>(type: "int", nullable: false),
                    ModuloId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "PESSOAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [PessoaBaseSequence]"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    NomeUsuario = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CriadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    AtualizadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PESSOAS_ENDERECOS_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "ENDERECOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PESSOASJURIDICAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [PessoaBaseSequence]"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false),
                    ResponsavelId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CriadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    AtualizadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOASJURIDICAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PESSOASJURIDICAS_ENDERECOS_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "ENDERECOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PESSOASJURIDICAS_PESSOAS_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "PESSOAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PessoaFisicaId = table.Column<int>(type: "int", nullable: false),
                    NomeUsuario = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false, defaultValue: 20),
                    PessoaFisicaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USUARIOS_PESSOAS_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalTable: "PESSOAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIOS_PESSOAS_PessoaFisicaId1",
                        column: x => x.PessoaFisicaId1,
                        principalTable: "PESSOAS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PessoaJuridicaId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioEmpresa_PESSOASJURIDICAS_PessoaJuridicaId",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "PESSOASJURIDICAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEmpresa_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioModulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EmpresaModuloId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioModulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioModulo_EmpresaModulo_EmpresaModuloId",
                        column: x => x.EmpresaModuloId,
                        principalTable: "EmpresaModulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioModulo_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIOS",
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

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_CPF",
                table: "PESSOAS",
                column: "CPF",
                unique: true,
                filter: "[CPF] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_Email",
                table: "PESSOAS",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_EmpresaId",
                table: "PESSOAS",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_EnderecoId",
                table: "PESSOAS",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_NomeUsuario",
                table: "PESSOAS",
                column: "NomeUsuario",
                unique: true,
                filter: "[NomeUsuario] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_Telefone",
                table: "PESSOAS",
                column: "Telefone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PESSOASJURIDICAS_EnderecoId",
                table: "PESSOASJURIDICAS",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOASJURIDICAS_ResponsavelId",
                table: "PESSOASJURIDICAS",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmpresa_PessoaJuridicaId",
                table: "UsuarioEmpresa",
                column: "PessoaJuridicaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmpresa_UsuarioId_PessoaJuridicaId",
                table: "UsuarioEmpresa",
                columns: new[] { "UsuarioId", "PessoaJuridicaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioModulo_EmpresaModuloId",
                table: "UsuarioModulo",
                column: "EmpresaModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioModulo_UsuarioId_EmpresaModuloId",
                table: "UsuarioModulo",
                columns: new[] { "UsuarioId", "EmpresaModuloId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_PessoaFisicaId",
                table: "USUARIOS",
                column: "PessoaFisicaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_PessoaFisicaId1",
                table: "USUARIOS",
                column: "PessoaFisicaId1",
                unique: true,
                filter: "[PessoaFisicaId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaModulo_PESSOASJURIDICAS_PessoaJuridicaId",
                table: "EmpresaModulo",
                column: "PessoaJuridicaId",
                principalTable: "PESSOASJURIDICAS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOAS_PESSOASJURIDICAS_EmpresaId",
                table: "PESSOAS",
                column: "EmpresaId",
                principalTable: "PESSOASJURIDICAS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAS_PESSOASJURIDICAS_EmpresaId",
                table: "PESSOAS");

            migrationBuilder.DropTable(
                name: "UsuarioEmpresa");

            migrationBuilder.DropTable(
                name: "UsuarioModulo");

            migrationBuilder.DropTable(
                name: "EmpresaModulo");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "Modulo");

            migrationBuilder.DropTable(
                name: "PESSOASJURIDICAS");

            migrationBuilder.DropTable(
                name: "PESSOAS");

            migrationBuilder.DropTable(
                name: "ENDERECOS");

            migrationBuilder.DropSequence(
                name: "PessoaBaseSequence");
        }
    }
}
