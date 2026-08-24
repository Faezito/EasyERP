using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Libraries.Filtros
{
    public class ValidateHttpRefererAttributes : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult("Index", "Acesso", null);
                return;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Possivel Logging
        }
    }
}