using Microsoft.AspNetCore.Mvc;
using Web.Libraries.Filtros;

namespace Web.Areas.Escolar.Controllers;

[Area("Escolar")]
[ValidateHttpRefererAttributes]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}