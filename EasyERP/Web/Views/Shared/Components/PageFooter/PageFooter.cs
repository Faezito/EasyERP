using Microsoft.AspNetCore.Mvc;

namespace Web.Views.Shared.Components.PageFooter;

public class PageFooterComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(PageFooter footer)
    {
        return View("Default", footer);
    }

    /*
        @await Component.InvokeAsync("FooterComponent", new Footer { Action = "", Controller = "", Area = null })
    */
}

public class PageFooter
{
    public string? Action { get; set; }
    public string? Controller { get; set; }
    public string? Area { get; set; } = string.Empty;
    public bool ExibeBotaoSalvar { get; set; } = true;
}