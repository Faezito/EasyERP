using CrossCutting.Auditoria;
using Model.DTOs.Endereco;

namespace Model.DTOs.PessoaFisica
{
    public class PessoaFisicaRespostaDTO : EntidadeAuditavel
    {
        private string _cpf = string.Empty;
        private string _telefone = string.Empty;
        private string _genero = string.Empty;

        public int Id { get; set; } // APENAS DEV, REMOVER
        public Guid PublicId { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Genero
        {
            get => _genero; set => _genero = value switch
            {
                "M" => "Masculino",
                "F" => "Feminino",
                _ => "Outro/Não informado"
            };
        }
        public string CPF
        {
            get => _cpf;
            set => _cpf = value ?? Convert.ToUInt64(value).ToString(@"000\.000\.000\-00");
        }
        public string Telefone
        {
            get => _telefone;
            set => _telefone = value ?? Convert.ToUInt64(value).ToString(@"(000) 00000-0000");
        }
        public string Email { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public EnderecoRespostaDTO? Endereco { get; set; }
    }
}