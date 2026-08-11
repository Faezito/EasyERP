using CrossCutting.Model.Enums;
using Model.DTOs.Endereco;
using System.Text.RegularExpressions;

namespace Model.DTOs.Escolar.Pessoa;

public class PessoaAtualizacaoDTO
{
    private string _telefone = string.Empty;

    public Guid PublicId { get; set; }
    public string? NomeCompleto { get; set; }
    public string? Genero { get; set; }
    public string? Email { get; set; }
    public string? Telefone
    {
        get => _telefone;
        set => _telefone = Regex.Replace(value ?? string.Empty, "[^0-9]", "");
    }
    public TipoDePessoa? Tipo { get; set; }
    public EnderecoAtualizacaoDTO? Endereco { get; set; }
}