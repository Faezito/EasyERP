namespace Escolar.Repositorio.Entidades;

public class Aluno
{
    public int Id { get; set; }
    public int PessoaId { get; set; }
    public int TurmaId { get; set; }

    public Pessoa Pessoa { get; set; } = null!;
    public List<AlunoResponsavel> Responsaveis { get; set; } = new();
    public Turma Turma { get; set; } = null!;
    public List<Presenca> Presencas { get; set; } = new List<Presenca>();
    public List<Nota> Notas { get; set; } = new List<Nota>();
}