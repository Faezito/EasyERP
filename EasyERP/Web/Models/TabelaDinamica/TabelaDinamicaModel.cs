namespace Web.Models.TabelaDinamica;

public class TabelaDinamicaModel
{
    public IEnumerable<object> Itens { get; set; } = [];
    public string? RotaEditar { get; set; }
    public string? RotaDeletar { get; set; }
    public bool Editavel {  get; set; }
}
