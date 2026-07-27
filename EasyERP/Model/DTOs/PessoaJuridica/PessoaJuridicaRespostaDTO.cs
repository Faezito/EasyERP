using Model.DTOs.Endereco;
using Model.DTOs.PessoaFisica;

namespace CrossCutting.Model.DTOs.PessoaJuridica
{
    public class PessoaJuridicaRespostaDTO
    {
        private string _cnpj = string.Empty;
        private string _telefone = string.Empty;

        public int Id { get; set; } // TODO: DELETAR
        public Guid PublicId { get; set; }
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
        public bool Ativo { get; set; }
        public PessoaFisicaRespostaDTO? Responsavel { get; set; }
        public EnderecoRespostaDTO? Endereco { get; set; }
    }
}
