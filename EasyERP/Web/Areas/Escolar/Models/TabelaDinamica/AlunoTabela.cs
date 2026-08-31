using CrossCutting.Model.DTOs.Escolar.Aluno;
using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Escolar.Models.TabelaDinamica;

public class AlunoTabela
{
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "Nome")]
    public string Name { get; set; }

    [Display(Name = "Email")]
    public string Email { get; set; }

    [Display(Name = "Telefone")]
    public string Telefone { get; set; }

    [Display(Name = "Endereço")]
    public string Endereco { get; set; }

    public static List<AlunoTabela> MapearParaTabela(List<AlunoRespostaDTO> pessoasRespostaDTO)
    {
        var pessoasTabela = new List<AlunoTabela>();
        foreach (var alunoDTO in pessoasRespostaDTO)
        {
            var pessoa = new AlunoTabela
            {
                Id = alunoDTO.Id,
                Name = alunoDTO.Pessoa.NomeCompleto,
                Email = alunoDTO.Pessoa.Email,
                Telefone = alunoDTO.Pessoa.Telefone,
                Endereco = $"{alunoDTO.Pessoa.Endereco.Logradouro} {alunoDTO.Pessoa.Endereco.Numero}, {alunoDTO.Pessoa.Endereco.Bairro} - {alunoDTO.Pessoa.Endereco.Cidade}, {alunoDTO.Pessoa.Endereco.Estado}"
            };

            pessoasTabela.Add(pessoa);
        }

        return pessoasTabela ?? new();
    }
}