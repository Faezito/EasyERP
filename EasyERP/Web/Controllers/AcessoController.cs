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
        var loginResult = await _acesso.Login(credenciais);

        var properties = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTime.UtcNow.AddHours(3)
        };

        properties.StoreTokens(new[]
        {
            new AuthenticationToken
            {
                Name = "access_token",
                Value = loginResult.Token
            }
        });

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            loginResult.Claims,
            properties
        );

        var auth = await HttpContext.AuthenticateAsync(
            CookieAuthenticationDefaults.AuthenticationScheme
        );

        var tokens = auth.Properties?.GetTokens().ToList();
        var token = auth.Properties?.GetTokenValue("access_token");

        return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}