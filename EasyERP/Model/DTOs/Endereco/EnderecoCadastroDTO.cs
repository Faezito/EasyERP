using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Model.DTOs.Endereco
{
    public class EnderecoCadastroDTO
    {
        private string _cep = string.Empty;

        public int? Id { get; set; }

        [Required(ErrorMessage = "CEP é necessário")]
        [Display(Name = "CEP")]
        public string CEP
        {
            get => _cep;
            set => _cep = Regex.Replace(value ?? string.Empty, "[^0-9]", "");
        }

        [StringLength(100, ErrorMessage = "O Complemento deve conter no máximo 100 caracteres")]
        [Display(Name = "Complemento")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "Número é necessário")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "O Número deve conter entre 1 e 10 caracteres")]
        [Display(Name = "Número")]
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "Logradouro é necessário")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O Logradouro deve conter entre 3 e 150 caracteres")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bairro é necessário")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O Bairro deve conter entre 2 e 100 caracteres")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cidade é necessária")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "A Cidade deve conter entre 2 e 100 caracteres")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "Estado é necessário")]
        [Display(Name = "Estado")]
        public string Estado { get; set; } = string.Empty;

        [Required(ErrorMessage = "País é necessário")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O País deve conter entre 2 e 100 caracteres")]
        [Display(Name = "País")]
        public string Pais { get; set; } = "Brasil";
    }
}