using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Views.Shared.Components.DropdownDinamicoComponent;

public class DropdownDinamicoComponent : ViewComponent
{
    public IViewComponentResult Invoke(DropDown model)
    {
        return View(model);
    }
}

public class DropDown
{
    public List<SelectListItem> Items { get; set; } = new List<SelectListItem>();
    public int? Selecionado { get; set; }
}

/*
    @await Component.InvokeAsync("DropdownDinamicoComponent", new { items = lst })
*/