namespace Usuarios.Model.Entidades
{
    public class PessoaFisica : PessoaBase
    {
        public string NomeCompleto { get; set; } = string.Empty;
        public string NomeUsuario { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public DateTime? DataNascimento { get; set; }
        public DateTime? UltimoAcesso { get; set; }

        public int? EmpresaId { get; set; }
        public PessoaJuridica? Empresa { get; set; }
    }
}