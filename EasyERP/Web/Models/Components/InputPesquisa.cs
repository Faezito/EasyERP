namespace Web.Models.Components;

public class InputPesquisa
{
    public string? Name { get; set; }
    public string? Placeholder { get; set; }
    public InputStyle? Estilo { get; set; }
}

public class InputStyle
{
    public string? Width { get; set; }
    public string? Col { get; set; }
}