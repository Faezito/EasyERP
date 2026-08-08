using CrossCutting.Model.Enums;
using Model.DTOs.Endereco;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Model.DTOs.Escolar.Pessoa;

public class PessoaAtualizacaoDTO
{
    private string _telefone = string.Empty;

    public Guid PublicId { get; set; }

    [Required(ErrorMessage = "Nome Completo é necessário")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome Completo precisa conter entre 3 e 100 caracteres")]
    [Display(Name = "Nome Completo")]
    public string NomeCompleto { get; set; } = string.Empty;

    [Required(ErrorMessage = "Gênero é necessário")]
    [Display(Name = "Gênero")]
    [RegularExpression("^[MFON]$", ErrorMessage = "O Gênero informado é inválido")]
    public string Genero { get; set; } = string.Empty;

    [Required(ErrorMessage = "E-mail é necessário")]
    [StringLength(150, ErrorMessage = "O E-mail deve conter no máximo 150 caracteres")]
    [Display(Name = "E-mail")]
    [EmailAddress(ErrorMessage = "O E-mail informado é inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Telefone é necessário")]
    [StringLength(11, MinimumLength = 10, ErrorMessage = "O telefone deve conter 10 ou 11 dígitos")]
    [Display(Name = "Telefone")]
    public string Telefone
    {
        get => _telefone;
        set => _telefone = Regex.Replace(value ?? string.Empty, "[^0-9]", "");
    }

    public TipoDePessoa Tipo { get; set; }
    public EnderecoAtualizacaoDTO Endereco { get; set; } = null!;
}