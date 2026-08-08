namespace CrossCutting.Auditoria;

public abstract class EntidadeAuditavel
{
    public DateTime? CriadoEm { get; set; }
    public Guid? CriadoPor { get; set; }
    public DateTime? AtualizadoEm { get; set; }
    public Guid? AtualizadoPor { get; set; }
    public bool Deletado { get; set; }
}