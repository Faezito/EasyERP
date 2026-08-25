using Microsoft.AspNetCore.Mvc;
using Web.Models.TabelaDinamica;

namespace Web.Views.Shared.Components.TabelaDinamica;

public class TabelaDinamica : ViewComponent
{
    public IViewComponentResult Invoke(TabelaDinamicaModel tabela)
    {
        return View("Default", tabela);
    }
}