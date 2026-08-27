using Biblioteca;

namespace Web.Models.Components;

public class Estilo
{
    public string? Id { get; set; } = KeyGenerator.GetUniqueKey(4);
    public string? Classe { get; set; }
}