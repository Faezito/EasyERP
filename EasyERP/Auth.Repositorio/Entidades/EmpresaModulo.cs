using CrossCutting.Auditoria;

namespace Auth.Repositorio.Entidades
{
    public class EmpresaModulo : EntidadeAuditavel
    {
        public int Id { get; set; }
        public int PessoaJuridicaId { get; set; }
        public int ModuloId { get; set; }

        public PessoaJuridica PessoaJuridica { get; set; } = null!;
        public Modulo Modulo { get; set; } = null!;
        public List<UsuarioModulo> Acessos { get; set; } = [];
    }
}