using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Models.Components;

namespace Web.Views.Shared.Components.DropAnosComponent;

public class DropAnosComponent : ViewComponent
{
    public IViewComponentResult Invoke(DropAnos dropAnos)
    {
        List<SelectListItem> lst = [];

        int ano = DateTime.Now.Year;

        for (int i = ano; i >= dropAnos.AnoInicio; i--)
        {
            if (dropAnos.AnoSelecionado != null)
            {
                lst.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString(), Selected = (i == dropAnos.AnoSelecionado) });
            }
            else
            {
                lst.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString(), Selected = (ano == i) });
            }
        }

        if (DateTime.Now.Month > 10)
            lst.Add(new SelectListItem { Value = (ano + 1).ToString(), Text = (ano + 1).ToString(), Selected = (ano + 1 == dropAnos.AnoSelecionado) });

        lst = lst.OrderByDescending(x => x.Value).ToList();

        return View("Default", lst);
    }
}