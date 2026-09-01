using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Authorize]
public class MenuController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Admin()
    {
        return View();
    }
}
