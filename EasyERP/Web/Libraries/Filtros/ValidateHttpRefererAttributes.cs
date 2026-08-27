using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Web.Extensions;

namespace Web.Libraries.Filtros;

public class ValidateHttpRefererAttributes : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var user = context.HttpContext.User;
        var area = context.RouteData.Values["area"]?.ToString();

        if (string.IsNullOrWhiteSpace(area))
            return;

        var acessos = user.ObterModulosDoUsuario();
        if (!acessos.Any(x => x.Nome.Equals(area, StringComparison.OrdinalIgnoreCase)))
        {
            context.Result = new RedirectToActionResult(
                "Index",
                "Home",
                new { area = "" }
            );

            return;
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        //Possivel Logging
    }
}