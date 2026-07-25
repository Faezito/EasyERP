using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Usuarios.Model.DTOs
{
    public class PessoaJuridicaCadastroDTO
    {
        private string _cnpj = string.Empty;
        private string _telefone = string.Empty;
        private string _telefoneResp = string.Empty;

        [Required(ErrorMessage = "Nome Fantasia é necessário")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome Fantasia precisa conter entre 3 e 100 caracteres")]
        [Display(Name = "Nome Fantasia")]
        public string? NomeFantasia { get; set; }

        [Required(ErrorMessage = "Razão Social é necessária")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "A Razão Social precisa conter entre 3 e 150 caracteres")]
        [Display(Name = "Razão Social")]
        public string? RazaoSocial { get; set; }

        [Required(ErrorMessage = "CNPJ é necessário")]
        [Display(Name = "CNPJ")]
        [RegularExpression(@"^[A-Z0-9]{14}$", ErrorMessage = "O CNPJ informado é inválido")]
        public string CNPJ
        {
            get => _cnpj;
            set => _cnpj = Regex.Replace(value ?? string.Empty, "[^A-Z0-9]", "").ToUpper().Trim();
        }

        [Required(ErrorMessage = "Telefone é necessário")]
        [Display(Name = "Telefone")]
        public string Telefone
        {
            get => _telefone;
            set => _telefone = Regex.Replace(value ?? string.Empty, "[^0-9]", "");
        }

        [Required(ErrorMessage = "E-mail é necessário")]
        [StringLength(150, ErrorMessage = "O E-mail deve conter no máximo 150 caracteres")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "O E-mail informado é inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha é necessária")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha deve conter entre 8 e 100 caracteres")]
        [Display(Name = "Senha")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "Nome do Responsável é necessário")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome do Responsável precisa conter entre 3 e 100 caracteres")]
        [Display(Name = "Nome do Responsável")]
        public string NomeDoResponsavel { get; set; }

        [Required(ErrorMessage = "Telefone do Responsável é necessário")]
        [Display(Name = "Telefone do Responsável")]
        public string TelefoneDoResponsavel
        {
            get => _telefoneResp;
            set => _telefoneResp = Regex.Replace(value ?? string.Empty, "[^0-9]", "");
        }

        [Required(ErrorMessage = "E-mail do Responsável é necessário")]
        [StringLength(150, ErrorMessage = "O E-mail deve conter no máximo 150 caracteres")]
        [Display(Name = "E-mail do Responsável")]
        [EmailAddress(ErrorMessage = "O E-mail informado é inválido")]
        public string EmailDoResponsavel { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
        public EnderecoCadastroDTO Endereco { get; set; }
    }

    public class PessoaJuridicaAlteracaoDTO
    {
        private string _telefone = string.Empty;
        private string _telefoneResp = string.Empty;

        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome Fantasia precisa conter entre 3 e 100 caracteres")]
        [Display(Name = "Nome Fantasia")]
        public string? NomeFantasia { get; set; }

        [StringLength(150, MinimumLength = 3, ErrorMessage = "A Razão Social precisa conter entre 3 e 150 caracteres")]
        [Display(Name = "Razão Social")]
        public string? RazaoSocial { get; set; }

        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve conter 14 caracteres")]
        [Display(Name = "CNPJ")]
        [RegularExpression(@"^[A-Z0-9]{14}$", ErrorMessage = "O CNPJ informado é inválido")]
        public string? CNPJ { get; set; }

        [StringLength(20, MinimumLength = 10, ErrorMessage = "O telefone deve conter 10 ou 11 dígitos")]
        [Display(Name = "Telefone")]
        public string? Telefone
        {
            get => _telefone;
            set => _telefone = Regex.Replace(value ?? string.Empty, "[^0-9]", "");
        }

        [StringLength(150, ErrorMessage = "O E-mail deve conter no máximo 150 caracteres")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "O E-mail informado é inválido")]
        public string? Email { get; set; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha deve conter entre 8 e 100 caracteres")]
        [Display(Name = "Senha")]
        public string? Senha { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome do Responsável precisa conter entre 3 e 100 caracteres")]
        [Display(Name = "Nome do Responsável")]
        public string? NomeDoResponsavel { get; set; }

        [StringLength(11, MinimumLength = 10, ErrorMessage = "O telefone deve conter 10 ou 11 dígitos")]
        [Display(Name = "Telefone do Responsável")]
        public string? TelefoneDoResponsavel
        {
            get => _telefoneResp;
            set => _telefoneResp = Regex.Replace(value ?? string.Empty, "[^0-9]", "");
        }

        [StringLength(150, ErrorMessage = "O E-mail deve conter no máximo 150 caracteres")]
        [Display(Name = "E-mail do Responsável")]
        [EmailAddress(ErrorMessage = "O E-mail informado é inválido")]
        public string? EmailDoResponsavel { get; set; }

        [Display(Name = "Ativo")]
        public bool? Ativo { get; set; }
    }
}