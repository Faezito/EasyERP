using CrossCutting.Auditoria;

namespace Usuarios.Repositorio.Entidades
{
    public class UsuarioModulo : EntidadeAuditavel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int EmpresaModuloId { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public EmpresaModulo EmpresaModulo { get; set; } = null!;
    }
}
