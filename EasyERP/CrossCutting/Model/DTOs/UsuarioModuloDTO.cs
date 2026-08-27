using CrossCutting.Auditoria;

namespace Model.DTOs;

public class UsuarioModuloDTO : EntidadeAuditavel
{
    public Guid UsuarioId { get; set; }
    public int ModuloId { get; set; }
    public ModuloDTO? Modulo { get; set; }
}
