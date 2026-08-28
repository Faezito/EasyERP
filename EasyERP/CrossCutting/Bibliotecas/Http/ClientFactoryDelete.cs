using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Bibliotecas.Http;

public interface IClientFactoryDelete
{
    Task<S?> Delete<S>(string endPoint, Api api);
}

public class ClientFactoryDelete : IClientFactoryDelete
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ClientFactoryDelete(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<S?> Delete<S>(string endPoint, Api api)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", api.Token);

        string url = $"{api.Url}{endPoint}";

        using HttpResponseMessage response = await httpClient.DeleteAsync(url);

        try
        {
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            return string.IsNullOrWhiteSpace(json)
                ? default
                : JsonConvert.DeserializeObject<S>(json);
        }
        catch (HttpRequestException)
        {
            throw await ExceptionCustom.Exception(response);
        }
    }
}