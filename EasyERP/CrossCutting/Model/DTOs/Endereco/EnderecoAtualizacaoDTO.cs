using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Model.DTOs.Endereco
{
    public class EnderecoAtualizacaoDTO
    {
        private string _cep = string.Empty;

        [Required(ErrorMessage = "Id é necessário")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve conter 8 dígitos")]
        [Display(Name = "CEP")]
        public string? CEP
        {
            get => _cep;
            set => _cep = Regex.Replace(value ?? string.Empty, "[^0-9]", "");
        }

        [StringLength(100, ErrorMessage = "O Complemento deve conter no máximo 100 caracteres")]
        [Display(Name = "Complemento")]
        public string? Complemento { get; set; }

        [StringLength(10, MinimumLength = 1, ErrorMessage = "O Número deve conter entre 1 e 10 caracteres")]
        [Display(Name = "Número")]
        public string? Numero { get; set; }

        [StringLength(150, MinimumLength = 3, ErrorMessage = "O Logradouro deve conter entre 3 e 150 caracteres")]
        [Display(Name = "Logradouro")]
        public string? Logradouro { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "O Bairro deve conter entre 2 e 100 caracteres")]
        [Display(Name = "Bairro")]
        public string? Bairro { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "A Cidade deve conter entre 2 e 100 caracteres")]
        [Display(Name = "Cidade")]
        public string? Cidade { get; set; }

        [StringLength(2, MinimumLength = 2, ErrorMessage = "O Estado deve conter 2 caracteres")]
        [Display(Name = "Estado")]
        public string? Estado { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "O País deve conter entre 2 e 100 caracteres")]
        [Display(Name = "País")]
        public string? Pais { get; set; }
    }

}
