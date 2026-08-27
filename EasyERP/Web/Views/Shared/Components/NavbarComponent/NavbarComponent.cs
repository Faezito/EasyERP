using Microsoft.AspNetCore.Mvc;
using Web.Models.Components;

namespace Web.Views.Shared.Components.NavbarComponent
{
    public class NavbarComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Navbar navbar)
        {
            return View("Default", navbar);
        }

        /*
            @await Component.InvokeAsync("NavbarComponent", new Navbar())
        */
    }
}

public class Navbar
{
    public string? Titulo { get; set; }
    public string? Logo { get; set; }
    public string? Background { get; set; }
    public string? Cor { get; set; }
    public List<NavbarLink> Links { get; set; } = [];
    public int ContagemAtualizacoes { get; set; }
    public List<string>? ListaAtualizacoes { get; set; }
}

public class NavbarLink
{
    public NavbarLink()
    {
        Estilo = new Estilo { Classe = "nav-link text-light" };
    }

    public required string Texto { get; set; }
    public required string Url { get; set; }
    public Estilo Estilo { get; set; } = new();
}


//<a class="nav-link text-light" asp-controller="Menu" asp-action="Index">MENU</a>