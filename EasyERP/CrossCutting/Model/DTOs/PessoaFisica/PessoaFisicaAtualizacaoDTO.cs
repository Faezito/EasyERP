using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Model.DTOs.PessoaFisica
{
    public class PessoaFisicaAtualizacaoDTO
    {
        private string _telefone = string.Empty;

        [Required(ErrorMessage = "Id é necessário")]
        [Display(Name = "Id")]
        public Guid PublicId { get; set; }

        [Display(Name = "Nome Completo")]
        public string? NomeCompleto { get; set; }

        [Display(Name = "Gênero")]
        [RegularExpression("^[MFON]$", ErrorMessage = "O Gênero informado é inválido")]
        public string? Genero { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone
        {
            get => _telefone;
            set => _telefone = Regex.Replace(value ?? string.Empty, "[^0-9]", "");
        }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "O E-mail informado é inválido")]
        public string? Email { get; set; }
    }
}