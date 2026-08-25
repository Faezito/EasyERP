using Biblioteca;

namespace Web.Models.Components;

public class BotaoComponent
{
    public string? Id { get; set; } = KeyGenerator.GetUniqueKey(6);
    public string? Texto { get; set; }
    public BotaoStyle Estilo { get; set; } = new();
    public string? Url { get; set; }

    public BotaoComponent () { }

    public BotaoComponent (string? id, string texto, BotaoStyle estilo, string? url)
    {
        Id = id;
        Texto = texto;
        Estilo = estilo;
        Url = url;
    }

    public BotaoComponent (string texto, BotaoStyle estilo, string? url)
    {
        Texto = texto;
        Estilo = estilo;
        Url = url;
    }
}

public class BotaoStyle
{
    public string? Classe { get; set; } = "btn btn-primary btn-sm";
    public bool Submit { get; set; }
    
    public BotaoStyle () { }

    public BotaoStyle (string? classe, bool submit = false)
    {
        Classe = classe;
        Submit = submit;
    }
}