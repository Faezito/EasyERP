using CrossCutting.Auditoria;

namespace Escolar.Repositorio.Entidades;

public class Turma : EntidadeAuditavel
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public string Sala { get; set; } = string.Empty;
    public string? Predio { get; set; }

    public int? ResponsavelId { get; set; }
    public int? ViceResponsavelId { get; set; }

    public Aluno? Responsavel { get; set; }
    public Aluno? ViceResponsavel { get; set; }
    public List<Aluno> Alunos { get; set; } = new();
}