using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Views.Shared.Components.DropMesesComponent;

public class DropMesesComponent : ViewComponent
{
    public IViewComponentResult Invoke(DropMeses dropMeses)
    {
        List<SelectListItem> lst = new();

        if (string.IsNullOrWhiteSpace(dropMeses.Mes))
        {
            dropMeses.Mes = DateTime.Now.Month.ToString();
        }

        lst.Add(new SelectListItem { Value = "1", Text = "Janeiro", Selected = dropMeses.Mes == "1" });
        lst.Add(new SelectListItem { Value = "2", Text = "Fevereiro", Selected = dropMeses.Mes == "2" });
        lst.Add(new SelectListItem { Value = "3", Text = "Março", Selected = dropMeses.Mes == "3" });
        lst.Add(new SelectListItem { Value = "4", Text = "Abril", Selected = dropMeses.Mes == "4" });
        lst.Add(new SelectListItem { Value = "5", Text = "Maio", Selected = dropMeses.Mes == "5" });
        lst.Add(new SelectListItem { Value = "6", Text = "Junho", Selected = dropMeses.Mes == "6" });
        lst.Add(new SelectListItem { Value = "7", Text = "Julho", Selected = dropMeses.Mes == "7" });
        lst.Add(new SelectListItem { Value = "8", Text = "Agosto", Selected = dropMeses.Mes == "8" });
        lst.Add(new SelectListItem { Value = "9", Text = "Setembro", Selected = dropMeses.Mes == "9" });
        lst.Add(new SelectListItem { Value = "10", Text = "Outubro", Selected = dropMeses.Mes == "10" });
        lst.Add(new SelectListItem { Value = "11", Text = "Novembro", Selected = dropMeses.Mes == "11" });
        lst.Add(new SelectListItem { Value = "12", Text = "Dezembro", Selected = dropMeses.Mes == "12" });

        return View("Default", lst);
    }
}

public class DropMeses
{
    public string? Mes { get; set; }
}
