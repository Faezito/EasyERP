namespace Web.Models.Components;

public class TopoMenu
{
    public string Titulo { get; set; } = string.Empty;
    public List<List<ItemDeSelect>>? SelectList { get; set; }
    public bool BtnPesquisar { get; set; }
    public bool BtnVoltar { get; set; }
    public bool DropAnos { get; set; }
    public bool DropMeses { get; set; }
}