using CrossCutting.Auditoria;

namespace Usuarios.Model.Entidades
{
    public class UsuarioEmpresa : EntidadeAuditavel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int PessoaJuridicaId { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public PessoaJuridica PessoaJuridica { get; set; } = null!;
    }
}