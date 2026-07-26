using CrossCutting.Model.Enums;

namespace Usuarios.Repositorio.Entidades
{
    public class PessoaJuridica : PessoaBase
    {
        public string NomeFantasia { get; set; } = string.Empty;
        public string RazaoSocial { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public EmpresaSituacao Situacao { get; set; }
        public List<EmpresaModulo> Acessos { get; set; } = [];
        public int ResponsavelId { get; set; }
        public PessoaFisica Responsavel { get; set; } = null!;
    }
}