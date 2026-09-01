using Model.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.TabelaDinamica;

public class ModuloTabela
{
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "Nome")]
    public string Nome { get; set; } = string.Empty;

    [Display(Name = "Descrição")]
    public string Descricao { get; set; } = string.Empty;

    [Display(Name = "Ativo")]
    public string Ativo { get; set; }

    [Display(Name = "Imagem")]
    public string? Imagem { get; set; }

    [Display(Name = "URL Base")]
    public string BaseUrl { get; set; } = string.Empty;

    [Display(Name = "Módulo Pai Id")]
    public int? ModuloPaiId { get; set; }

    public static List<ModuloTabela> MapearParaTabela(List<ModuloDTO> modulosDTO)
    {
        var modulosTabela = new List<ModuloTabela>();
        foreach (var moduloDTO in modulosDTO)
        {
            var modulo = new ModuloTabela
            {
                Id = moduloDTO.Id,
                Nome = moduloDTO.Nome,
                Descricao = moduloDTO.Descricao,
                Ativo = moduloDTO.Ativo == true ? "Ativo" : "Inativo",
                Imagem = moduloDTO.Imagem,
                BaseUrl = moduloDTO.BaseUrl,
                ModuloPaiId = moduloDTO.ModuloPaiId
            };

            modulosTabela.Add(modulo);
        }

        return modulosTabela ?? new();
    }
}
