using Model.DTOs.Escolar.Pessoa;
using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Escolar.Models.TabelaDinamica;

public class PessoaTabela
{
    [Display(Name = "Id")]
    public Guid Id { get; set; }

    [Display(Name = "Nome")]
    public string Name { get; set; }

    [Display(Name = "Email")]
    public string Email { get; set; }

    [Display(Name = "Telefone")]
    public string Telefone { get; set; }

    [Display(Name = "Endereço")]
    public string Endereco { get; set; }


    public static List<PessoaTabela> MapearParaTabela(List<PessoaRespostaDTO> pessoasRespostaDTO)
    {
        var pessoasTabela = new List<PessoaTabela>();
        foreach (var pessoaDTO in pessoasRespostaDTO)
        {
            var pessoa = new PessoaTabela
            {
                Id = pessoaDTO.PublicId,
                Name = pessoaDTO.NomeCompleto,
                Email = pessoaDTO.Email,
                Telefone = pessoaDTO.Telefone,
                Endereco = $"{pessoaDTO.Endereco.Logradouro} {pessoaDTO.Endereco.Numero}, {pessoaDTO.Endereco.Bairro} - {pessoaDTO.Endereco.Cidade}, {pessoaDTO.Endereco.Estado}"
            };

            pessoasTabela.Add(pessoa);
        }

        return pessoasTabela ?? new();
    }
}