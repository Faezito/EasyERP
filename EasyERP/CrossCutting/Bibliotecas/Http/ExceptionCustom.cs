using Bibliotecas.Exceptions;
using System.Text.Json;

namespace Bibliotecas.Http;

public static class ExceptionCustom
{
    public static async Task Exception(HttpResponseMessage response)
    {
        var json = await response.Content.ReadAsStringAsync();

        var problem = JsonSerializer.Deserialize<ApiProblemDetails>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        if (problem == null)
        {
            throw new Exception(json);
        }

        throw new HttpException(problem);
    }
}