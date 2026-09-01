using System.ComponentModel.DataAnnotations;

namespace Model.DTOs;

public class ModuloDTO
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public bool Ativo { get; set; } = true;
    public string? Imagem { get; set; }

    public string? BaseUrl { get; set; }
    public int? ModuloPaiId { get; set; }
}

public class ModuloCadastroDTO
{
    [Display(Name = "Nome")]
    public string? Nome { get; set; }

    [Display(Name = "Descrição")]
    public string? Descricao { get; set; }

    [Display(Name = "Ativo")]
    public bool Ativo { get; set; } = true;

    [Display(Name = "Imagem")]
    public string? Imagem { get; set; }

    [Display(Name = "URL Base")]
    public string? BaseUrl { get; set; }

    [Display(Name = "Módulo Pai")]
    public int? ModuloPaiId { get; set; }
}
