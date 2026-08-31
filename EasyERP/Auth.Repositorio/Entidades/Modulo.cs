namespace Auth.Repositorio.Entidades
{
    public class Modulo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;

        public string BaseUrl { get; set; } = string.Empty;
        public int? ModuloPaiId { get; set; }

        public List<UsuarioModulo> Usuarios { get; set; } = [];
    }
}