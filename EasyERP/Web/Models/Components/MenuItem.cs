namespace Web.Models.Components;

public class MenuItem
{
    public string Texto { get; set; } = string.Empty;
    public string Controller { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public string Icone { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public string? TipoPermitido { get; set; }
}
