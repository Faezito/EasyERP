using Model.DTOs.Escolar.Disciplina;
using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Escolar.Models.TabelaDinamica;

public class DisciplinaTabela
{
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "Nome")]
    public string Nome { get; set; } = string.Empty;

    [Display(Name = "Descrição")]
    public string Descricao { get; set; } = string.Empty;

    [Display(Name = "Ativa", Description = "text-center")]
    public string Ativa { get; set; } = string.Empty;

    public static List<DisciplinaTabela> MapearParaTabela(List<DisciplinaRespostaDTO> disciplinasDTO)
    {
        var disciplinasTabela = new List<DisciplinaTabela>();
        foreach (var disciplinaDTO in disciplinasDTO)
        {
            var disciplina = new DisciplinaTabela
            {
                Id = disciplinaDTO.Id,
                Nome = disciplinaDTO.Nome,
                Descricao = disciplinaDTO.Descricao,
                Ativa = disciplinaDTO.Ativa ? "Sim" : "Não"
            };

            disciplinasTabela.Add(disciplina);
        }

        return disciplinasTabela ?? new();
    }
}
