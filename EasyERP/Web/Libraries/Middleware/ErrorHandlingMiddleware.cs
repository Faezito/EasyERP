using Microsoft.AspNetCore.Mvc;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(
        RequestDelegate next,
        ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(
        HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var problem = new ProblemDetails
            {
                Title = "Erro",
                Detail = ex.Message,
                Status = 500
            };

            _logger.LogError(ex,
                "Erro não tratado. URL: {Url}",
                context.Request.Path);

            context.Response.Clear();
            context.Response.StatusCode = problem.Status ?? 500;

            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}