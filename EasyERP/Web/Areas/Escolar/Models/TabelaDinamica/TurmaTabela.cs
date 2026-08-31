using Model.DTOs.Escolar.Turma;
using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Escolar.Models.TabelaDinamica;

public class TurmaTabela
{
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "Descrição")]
    public string Descricao { get; set; } = string.Empty;

    [Display(Name = "Sala")]
    public string Sala { get; set; } = string.Empty;

    [Display(Name = "Prédio")]
    public string? Predio { get; set; }

    [Display(Name = "Responsável Id")]
    public int? ResponsavelId { get; set; }

    [Display(Name = "Vice-Responsável Id")]
    public int? ViceResponsavelId { get; set; }

    public static List<TurmaTabela> MapearParaTabela(List<TurmaDTO> turmasDTO)
    {
        var turmasTabela = new List<TurmaTabela>();
        foreach (var turmaDTO in turmasDTO)
        {
            var turma = new TurmaTabela
            {
                Id = turmaDTO.Id,
                Descricao = turmaDTO.Descricao,
                Sala = turmaDTO.Sala,
                Predio = turmaDTO.Predio,
                ResponsavelId = turmaDTO.ResponsavelId,
                ViceResponsavelId = turmaDTO.ViceResponsavelId
            };

            turmasTabela.Add(turma);
        }

        return turmasTabela ?? new();
    }
}
