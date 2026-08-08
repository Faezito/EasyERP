using CrossCutting.Auditoria;

namespace Escolar.Repositorio.Entidades;

public class Nota : EntidadeAuditavel
{
    public int Id { get; set; }

    public int AlunoId { get; set; }
    public int ProfessorId { get; set; }
    public int DisciplinaId { get; set; }
    public int TurmaId { get; set; }

    public decimal PontosFeitos { get; set; }
    public decimal TotalPontos { get; set; }
    public DateTime DataLancamento { get; set; } = DateTime.Now;

    public Aluno Aluno { get; set; } = null!;
    public Pessoa Professor { get; set; } = null!;
    public Disciplina Disciplina { get; set; } = null!;
    public Turma Turma { get; set; } = null!;
}