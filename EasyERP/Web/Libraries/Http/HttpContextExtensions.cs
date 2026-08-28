using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Web.Libraries.Http;

public static class HttpContextExtensions
{
    public static async Task<string?> GetJwtAsync(
        this HttpContext httpContext)
    {
        var result = await httpContext.AuthenticateAsync(
            CookieAuthenticationDefaults.AuthenticationScheme
        );

        return result.Properties?.GetTokenValue("access_token");
    }
}