using CrossCutting.Auditoria;

namespace Auth.Repositorio.Entidades;

public class UsuarioModulo : EntidadeAuditavel
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int ModuloId { get; set; }

    public Usuario Usuario { get; set; } = null!;
    public Modulo Modulo { get; set; } = null!;
}
