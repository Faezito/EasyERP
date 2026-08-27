using Microsoft.AspNetCore.Mvc;
using Web.Models.Components;

namespace Web.Views.Shared.Components.CardMenuComponent;

public class CardMenuComponent : ViewComponent
{
    public IViewComponentResult Invoke(CardMenu component)
    {
        return View("Default", component);
    }
}

public class CardMenu
{
    public string? Texto { get; set; }
    public string? Imagem { get; set; }
    public Estilo Estilo { get; set; } = new Estilo { Classe = "" };
    public string? Url { get; set; }
}