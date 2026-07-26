using Usuarios.Model.Enums;

namespace Usuarios.Model.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public int PessoaFisicaId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public Perfil Perfil { get; set; }

        public PessoaFisica PessoaFisica { get; set; } = null!;
        public List<UsuarioModulo> Acessos { get; set; } = [];
    }
}