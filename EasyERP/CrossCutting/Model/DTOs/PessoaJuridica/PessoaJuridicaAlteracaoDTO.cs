using CrossCutting.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CrossCutting.Model.DTOs.PessoaJuridica;

public class PessoaJuridicaAlteracaoDTO
{
    private string _telefone = string.Empty;

    public Guid PublicId { get; set; }

    [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome Fantasia precisa conter entre 3 e 100 caracteres")]
    [Display(Name = "Nome Fantasia")]
    public string? NomeFantasia { get; set; }

    [StringLength(150, MinimumLength = 3, ErrorMessage = "A Razão Social precisa conter entre 3 e 150 caracteres")]
    [Display(Name = "Razão Social")]
    public string? RazaoSocial { get; set; }

    [StringLength(20, MinimumLength = 10, ErrorMessage = "O telefone deve conter 10 ou 11 dígitos")]
    [Display(Name = "Telefone")]
    public string? Telefone
    {
        get => _telefone;
        set => _telefone = Regex.Replace(value ?? string.Empty, "[^0-9]", "");
    }

    [Display(Name = "Responsável")]
    public Guid? ResponsavelPublicId { get; set; }

    [Display(Name = "Situação")]
    public EmpresaSituacao Situacao { get; set; }
}