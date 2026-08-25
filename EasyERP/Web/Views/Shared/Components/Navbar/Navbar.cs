using Microsoft.AspNetCore.Mvc;

namespace Web.Views.Shared.Components.Navbar
{
    public class Navbar : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default", new Navbar());
        }

        /*
            @await Component.InvokeAsync("Navbar")
        */
    }
}
