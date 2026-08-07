using Newtonsoft.Json;
using System.Text;

namespace Bibliotecas.Http;

public interface IClientFactoryPut
{
    Task<S?> Put<T, S>(string endPoint, T body, int apiId);
    Task Put<T>(string endPoint, T body, int apiId);
}

public class ClientFactoryPut : IClientFactoryPut
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IAPIsServicos _api;

    public ClientFactoryPut(IHttpClientFactory httpClientFactory, IAPIsServicos api)
    {
        _httpClientFactory = httpClientFactory;
        _api = api;
    }

    public async Task<S?> Put<T, S>(string endPoint, T body, int apiId)
    {
        var api = await _api.ObterPorCodigo(apiId); // devtools 151

        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-API-Key", api.Token);

        string url = $"{api.Url}{endPoint}";

        string jsonBody = JsonConvert.SerializeObject(body);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        using HttpResponseMessage response = await httpClient.PutAsync(url, content);

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

    public async Task Put<T>(string endPoint, T body, int apiId)
    {
        var api = await _api.ObterPorCodigo(apiId); // devtools 151

        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-API-Key", api.Token);

        string url = $"{api.Url}{endPoint}";

        string jsonBody = JsonConvert.SerializeObject(body);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        using HttpResponseMessage response = await httpClient.PutAsync(url, content);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException)
        {
            throw await ExceptionCustom.Exception(response);
        }
    }
}