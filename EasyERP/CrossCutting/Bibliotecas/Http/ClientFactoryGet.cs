using Newtonsoft.Json;

namespace Bibliotecas.Http;

public interface IClientFactoryGet
{
    Task<S> Get<S>(string endPoint, Api api);
    Task<S> Get<S>(string url, string endpoint, string token);
}

public class ClientFactoryGet : IClientFactoryGet
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ClientFactoryGet(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<S?> Get<S>(string endPoint, Api api)
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient(api.Url);

            httpClient.DefaultRequestHeaders.Add("X-API-Key", api.Token);

            string url = $"{api.Url}{endPoint}";

            httpClient.DefaultRequestHeaders.Accept.Clear();

            using (HttpResponseMessage response = await httpClient.GetAsync(url))
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                    string json = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrWhiteSpace(json))
                    {
                        return default;
                    }
                    return JsonConvert.DeserializeObject<S>(json);
                }
                catch (Exception)
                {
                    throw await ExceptionCustom.Exception(response);
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<S> Get<S>(string url, string endpoint, string token)
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient(url);

            httpClient.DefaultRequestHeaders.Add("X-API-Key", token);

            string urlCompleta = $"{url}{endpoint}";

            httpClient.DefaultRequestHeaders.Accept.Clear();

            using (HttpResponseMessage response = await httpClient.GetAsync(urlCompleta))
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                    string json = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrWhiteSpace(json))
                    {
                        return default;
                    }
                    return JsonConvert.DeserializeObject<S>(json);
                }
                catch (Exception)
                {
                    throw await ExceptionCustom.Exception(response);
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
