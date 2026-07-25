using CrossCutting.Auditoria;

namespace Usuarios.Model.Entidades
{
    public class EmpresaModulo : EntidadeAuditavel
    {
        public int Id { get; set; }
        public int PessoaJuridicaId { get; set; }
        public int ModuloId { get; set; }

        public PessoaJuridica PessoaJuridica { get; set; } = null!;
        public Modulo Modulo { get; set; } = null!;
    }

    // temporário
    public class Modulo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
    }
}