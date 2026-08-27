using Biblioteca;

namespace Web.Models.Components;

public class BotaoComponent
{
    public string? Id { get; set; } = KeyGenerator.GetUniqueKey(6);
    public string? Texto { get; set; }
    public BotaoStyle Estilo { get; set; } = new();
    public string? Url { get; set; }
    public string? OnClick { get; set; }

    public BotaoComponent() { }

    public BotaoComponent(string? id, string texto, BotaoStyle estilo, string? url)
    {
        Id = id;
        Texto = texto;
        Estilo = estilo;
        Url = url;
    }

    public BotaoComponent(string texto, BotaoStyle estilo, string? url)
    {
        Texto = texto;
        Estilo = estilo;
        Url = url;
    }

    public BotaoComponent(string? url, string? onclick)
    {
        Texto = "<i class=\"fa-solid fa-reply\"></i>&nbsp; Voltar";
        Estilo = new BotaoStyle("btn btn-secondary btn-sm col-auto");
        Url = url;
        OnClick = onclick;
    }
}

public class BotaoStyle : Estilo
{
    public bool Submit { get; set; }

    public BotaoStyle()
    {
        Classe = "btn btn-primary btn-sm";
    }

    public BotaoStyle(string? classe, bool submit = false)
    {
        Classe = classe;
        Submit = submit;
    }
}