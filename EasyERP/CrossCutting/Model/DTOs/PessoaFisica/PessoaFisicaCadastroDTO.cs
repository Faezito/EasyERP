using Model.DTOs.Endereco;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Model.DTOs.PessoaFisica
{
    public class PessoaFisicaCadastroDTO
    {
        private string _cpf = string.Empty;
        private string _telefone = string.Empty;

        [Required(ErrorMessage = "Nome Completo é necessário")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome Completo precisa conter entre 3 e 100 caracteres")]
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "Gênero é necessário")]
        [Display(Name = "Gênero")]
        [RegularExpression("^[MFON]$", ErrorMessage = "O Gênero informado é inválido")]
        public string Genero { get; set; } = string.Empty;

        [Required(ErrorMessage = "CPF é necessário")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 dígitos")]
        [Display(Name = "CPF")]
        public string CPF
        {
            get => _cpf;
            set => _cpf = Regex.Replace(value ?? string.Empty, "[^0-9]", "");
        }

        [Required(ErrorMessage = "Telefone é necessário")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "O telefone deve conter 10 ou 11 dígitos")]
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
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data de Nascimento é necessária")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        public int UsuarioAlteracaoId { get; set; }
        public EnderecoCadastroDTO Endereco { get; set; }
    }
}