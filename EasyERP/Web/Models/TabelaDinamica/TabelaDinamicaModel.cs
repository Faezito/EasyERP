namespace Web.Models.TabelaDinamica;

public class TabelaDinamicaModel
{
    public TabelaDinamicaModel() { }
    public TabelaDinamicaModel(IEnumerable<object> lista, string? rotaEditar, string? rotaDeletar, bool editavel = false)
    {
        Itens = lista;
        RotaEditar = rotaEditar;
        RotaDeletar = rotaDeletar;
        Editavel = editavel;
    }

    public IEnumerable<object> Itens { get; set; } = [];
    public string? RotaEditar { get; set; }
    public string? RotaDeletar { get; set; }
    public bool Editavel {  get; set; }
}
