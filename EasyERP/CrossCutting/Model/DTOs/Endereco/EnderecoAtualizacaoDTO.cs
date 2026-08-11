using System.Text.RegularExpressions;

namespace Model.DTOs.Endereco
{
    public class EnderecoAtualizacaoDTO
    {
        private string _cep = string.Empty;
        public int Id { get; set; }
        public string? CEP
        {
            get => _cep;
            set => _cep = Regex.Replace(value ?? string.Empty, "[^0-9]", "");
        }
        public string? Complemento { get; set; }
        public string? Numero { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }
    }

}
