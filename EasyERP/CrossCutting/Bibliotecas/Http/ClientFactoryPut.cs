using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Bibliotecas.Http;

public interface IClientFactoryPut
{
    Task<S?> Put<T, S>(string endPoint, T body, Api api);
    Task Put<T>(string endPoint, T body, Api api);
}

public class ClientFactoryPut : IClientFactoryPut
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ClientFactoryPut(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<S?> Put<T, S>(string endPoint, T body, Api api)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", api.Token);

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

    public async Task Put<T>(string endPoint, T body, Api api)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", api.Token);

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