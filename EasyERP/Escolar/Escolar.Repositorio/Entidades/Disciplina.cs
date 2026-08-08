using CrossCutting.Auditoria;

namespace Escolar.Repositorio.Entidades;

public class Disciplina : EntidadeAuditavel
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public bool Ativa { get; set; } = true;

    public List<Nota> Notas { get; set; } = new();
    public List<Presenca> Presencas { get; set; } = new();
}