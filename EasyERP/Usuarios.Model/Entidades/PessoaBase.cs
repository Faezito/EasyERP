using CrossCutting.Auditoria;

namespace Usuarios.Model.Entidades
{
    public abstract class PessoaBase :EntidadeAuditavel
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; } = null!;
    }
}
