using CrossCutting.Auditoria;

namespace Escolar.Repositorio.Entidades;

public class Presenca : EntidadeAuditavel
{
    public int Id { get; set; }
    public int AlunoId { get; set; }
    public int ProfessorId { get; set; }
    public int TurmaId { get; set; }
    public int DisciplinaId { get; set; }
    public DateTime Data { get; set; }
    public bool Presente { get; set; }

    public Aluno Aluno { get; set; } = null!;
    public Pessoa Professor { get; set; } = null!;
    public Turma Turma { get; set; } = null!;
    public Disciplina Disciplina { get; set; } = null!;
}