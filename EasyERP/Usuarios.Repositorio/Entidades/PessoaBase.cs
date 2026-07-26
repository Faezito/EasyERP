using CrossCutting.Auditoria;

namespace Usuarios.Repositorio.Entidades
{
    public abstract class PessoaBase :EntidadeAuditavel
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; } = Guid.CreateVersion7();
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; } = null!;
    }
}
