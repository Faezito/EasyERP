namespace Web.Models.Components;

public class InputPesquisa
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Placeholder { get; set; }
    public InputStyle? Estilo { get; set; }
}

public class InputStyle
{
    public string? Width { get; set; } = "auto";
    public string? Col { get; set; } = "auto";
}