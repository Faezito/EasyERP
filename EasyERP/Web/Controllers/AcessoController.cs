using CrossCutting.Model.DTOs.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Web.Services;

namespace Web.Controllers;

public class AcessoController(IAcessoServices acesso) : Controller
{
    private readonly IAcessoServices _acesso = acesso;

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequestDTO credenciais)
    {
        var claims = await _acesso.Login(credenciais);
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            claims,
            new AuthenticationProperties()
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddHours(3)
            }
        );

        return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
    }
}