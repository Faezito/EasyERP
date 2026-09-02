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
    public IActionResult Index(string? returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;

        if (User.Identity != null && User.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Home");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequestDTO credenciais, string? returnUrl)
    {
        var loginResult = await _acesso.Login(credenciais);
        var url = string.IsNullOrWhiteSpace(returnUrl) ? Url.Action("Index", "Home") : returnUrl;

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

        return Json(new { success = true, redirectUrl = url });
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}