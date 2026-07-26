using CrossCutting.Auditoria;

namespace Usuarios.Model.Entidades
{
    public class UsuarioAcesso : EntidadeAuditavel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int Permissao { get; set; }
    }
}