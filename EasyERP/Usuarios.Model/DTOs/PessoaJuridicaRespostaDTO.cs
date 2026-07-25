using Usuarios.Model.Entidades;

namespace Usuarios.Model.DTOs
{
    public class PessoaJuridicaRespostaDTO
    {
        private string _cnpj = string.Empty;
        private string _telefone = string.Empty;
        private string _telefoneResp = string.Empty;

        public int Id { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public string CNPJ
        {
            get => _cnpj;
            set
            {
                var valor = new string((value ?? "")
                    .Where(char.IsLetterOrDigit)
                    .ToArray())
                    .ToUpper();

                if (valor.Length != 14)
                    throw new ArgumentException("O CNPJ deve possuir 14 caracteres.");

                _cnpj = $"{valor[..2]}.{valor[2..5]}.{valor[5..8]}/{valor[8..12]}-{valor[12..14]}";
            }
        }
        public string Telefone
        {
            get => _telefone;
            set => _telefone = Convert.ToUInt64(value).ToString(@"(000) 00000-0000");
        }
        public string? Email { get; set; }
        public string NomeDoResponsavel { get; set; }
        public string TelefoneDoResponsavel
        {
            get => _telefoneResp;
            set => _telefoneResp = Convert.ToUInt64(value).ToString(@"(000) 00000-0000");
        }
        public string EmailDoResponsavel { get; set; }
        public bool Ativo { get; set; }
        public Endereco Endereco { get; set; }
    }
}
