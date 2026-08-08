using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escolar.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class Migracao_Inicial_Tabelas_Base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Escolar");

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                schema: "Escolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CriadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    AtualizadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                schema: "Escolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CriadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    AtualizadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                schema: "Escolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PessoaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalSchema: "Escolar",
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enderecos_Pessoas_PessoaId1",
                        column: x => x.PessoaId1,
                        principalSchema: "Escolar",
                        principalTable: "Pessoas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                schema: "Escolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalSchema: "Escolar",
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlunosResponsaveis",
                schema: "Escolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    Parentesco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResponsavelFinanceiro = table.Column<bool>(type: "bit", nullable: false),
                    ResponsavelPedagogico = table.Column<bool>(type: "bit", nullable: false),
                    ContatoEmergencia = table.Column<bool>(type: "bit", nullable: false),
                    PodeRetirarAluno = table.Column<bool>(type: "bit", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CriadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    AtualizadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosResponsaveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunosResponsaveis_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalSchema: "Escolar",
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlunosResponsaveis_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalSchema: "Escolar",
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                schema: "Escolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Sala = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Predio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ResponsavelId = table.Column<int>(type: "int", nullable: true),
                    ViceResponsavelId = table.Column<int>(type: "int", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CriadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    AtualizadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turmas_Alunos_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalSchema: "Escolar",
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turmas_Alunos_ViceResponsavelId",
                        column: x => x.ViceResponsavelId,
                        principalSchema: "Escolar",
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                schema: "Escolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false),
                    PontosFeitos = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    TotalPontos = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CriadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    AtualizadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalSchema: "Escolar",
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalSchema: "Escolar",
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notas_Pessoas_ProfessorId",
                        column: x => x.ProfessorId,
                        principalSchema: "Escolar",
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalSchema: "Escolar",
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Presencas",
                schema: "Escolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Presente = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CriadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    AtualizadoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presencas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presencas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalSchema: "Escolar",
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Presencas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalSchema: "Escolar",
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Presencas_Pessoas_ProfessorId",
                        column: x => x.ProfessorId,
                        principalSchema: "Escolar",
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Presencas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalSchema: "Escolar",
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_PessoaId",
                schema: "Escolar",
                table: "Alunos",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmaId",
                schema: "Escolar",
                table: "Alunos",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosResponsaveis_AlunoId_PessoaId",
                schema: "Escolar",
                table: "AlunosResponsaveis",
                columns: new[] { "AlunoId", "PessoaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlunosResponsaveis_PessoaId",
                schema: "Escolar",
                table: "AlunosResponsaveis",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_Nome",
                schema: "Escolar",
                table: "Disciplinas",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PessoaId",
                schema: "Escolar",
                table: "Enderecos",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PessoaId1",
                schema: "Escolar",
                table: "Enderecos",
                column: "PessoaId1",
                unique: true,
                filter: "[PessoaId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_AlunoId",
                schema: "Escolar",
                table: "Notas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_DisciplinaId",
                schema: "Escolar",
                table: "Notas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_ProfessorId",
                schema: "Escolar",
                table: "Notas",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_TurmaId",
                schema: "Escolar",
                table: "Notas",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CPF",
                schema: "Escolar",
                table: "Pessoas",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_Email",
                schema: "Escolar",
                table: "Pessoas",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_PublicId",
                schema: "Escolar",
                table: "Pessoas",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_Telefone",
                schema: "Escolar",
                table: "Pessoas",
                column: "Telefone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presencas_AlunoId",
                schema: "Escolar",
                table: "Presencas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Presencas_DisciplinaId",
                schema: "Escolar",
                table: "Presencas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Presencas_ProfessorId",
                schema: "Escolar",
                table: "Presencas",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Presencas_TurmaId",
                schema: "Escolar",
                table: "Presencas",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_ResponsavelId",
                schema: "Escolar",
                table: "Turmas",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_ViceResponsavelId",
                schema: "Escolar",
                table: "Turmas",
                column: "ViceResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                schema: "Escolar",
                table: "Alunos",
                column: "TurmaId",
                principalSchema: "Escolar",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Pessoas_PessoaId",
                schema: "Escolar",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                schema: "Escolar",
                table: "Alunos");

            migrationBuilder.DropTable(
                name: "AlunosResponsaveis",
                schema: "Escolar");

            migrationBuilder.DropTable(
                name: "Enderecos",
                schema: "Escolar");

            migrationBuilder.DropTable(
                name: "Notas",
                schema: "Escolar");

            migrationBuilder.DropTable(
                name: "Presencas",
                schema: "Escolar");

            migrationBuilder.DropTable(
                name: "Disciplinas",
                schema: "Escolar");

            migrationBuilder.DropTable(
                name: "Pessoas",
                schema: "Escolar");

            migrationBuilder.DropTable(
                name: "Turmas",
                schema: "Escolar");

            migrationBuilder.DropTable(
                name: "Alunos",
                schema: "Escolar");
        }
    }
}
