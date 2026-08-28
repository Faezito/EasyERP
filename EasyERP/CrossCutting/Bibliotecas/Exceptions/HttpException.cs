using Bibliotecas.Http;

namespace Bibliotecas.Exceptions;

public class HttpException : Exception
{
    public ApiProblemDetails Problem { get; }

    public HttpException(ApiProblemDetails problem)
        : base(problem.Detail)
    {
        Problem = problem;
    }
}