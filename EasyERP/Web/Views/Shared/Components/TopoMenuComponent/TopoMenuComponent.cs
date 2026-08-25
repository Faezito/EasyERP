using Microsoft.AspNetCore.Mvc;
using Web.Models.Components;
using Web.Views.Shared.Components.DropMesesComponent;

namespace Web.Views.Shared.Components.TopoMenus;

public class TopoMenuComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(TopoMenu menu)
    {
        return View("Default", menu);
    }
}

/*
await Component.InvokeAsync("TopoMenuComponent", new TopoMenu { Menu = "Relatórios", Ajuda = false, Rota = "@Url.Action("","") })
*/

public class TopoMenu
{
    public string Titulo { get; set; } = string.Empty;
    public List<BotaoComponent> Botoes { get; set; } = [];
    public DropAnos? DropAnos { get; set; }
    public DropMeses? DropMeses { get; set; }
}