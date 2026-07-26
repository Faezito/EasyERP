using CrossCutting.Auditoria;
using CrossCutting.Model.Enums;

namespace Usuarios.Repositorio.Entidades
{
    public class Usuario : EntidadeAuditavel
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; } = Guid.CreateVersion7();
        public int PessoaFisicaId { get; set; }
        public string NomeUsuario { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public Perfil Perfil { get; set; }

        public PessoaFisica PessoaFisica { get; set; } = null!;
        public List<UsuarioModulo> Acessos { get; set; } = [];
    }
}