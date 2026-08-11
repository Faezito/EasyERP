using CrossCutting.Model.Enums;
using Model.DTOs.Endereco;
using System.Text.RegularExpressions;

namespace Model.DTOs.Escolar.Pessoa;

public class PessoaRespostaDTO
{
    private string _cpf = string.Empty;
    private string _telefone = string.Empty;

    public Guid PublicId { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CPF
    {
        get => _cpf;
        set => _cpf = Regex.Replace(value ?? string.Empty, "[^0-9]", "");
    }
    public string Telefone
    {
        get => _telefone;
        set => _telefone = Regex.Replace(value ?? string.Empty, "[^0-9]", "");
    }
    public DateTime DataNascimento { get; set; }
    public TipoDePessoa Tipo { get; set; }
    public EnderecoRespostaDTO Endereco { get; set; } = null!;
}
