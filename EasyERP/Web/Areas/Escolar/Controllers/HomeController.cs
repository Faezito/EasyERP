using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Escolar.Controllers;

[Area("Escolar")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
