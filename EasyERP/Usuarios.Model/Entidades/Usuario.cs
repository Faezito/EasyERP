namespace Usuarios.Model.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public Guid PessoaFisicaId { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public Perfil Perfil { get; set; }

        public PessoaFisica PessoaFisica { get; set; }
    }


    public enum Perfil
    {
        Super = 0,
        AdministradorDoSistema = 1,
        Administrador = 5,
        Usuario = 10,
    }
}
