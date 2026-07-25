using CrossCutting.Auditoria;

namespace Usuarios.Model.Entidades
{
    public class UsuarioAcesso : EntidadeAuditavel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int Acesso { get; set; }
    }

    public enum Acesso
    {
        Acesso = 1,
        Financeiro = 2,
        RH = 3,
        DP = 4,
        Estoque = 5,
        Condominio = 10,
    }
}
