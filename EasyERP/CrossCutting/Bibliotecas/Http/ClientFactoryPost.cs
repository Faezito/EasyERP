using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Bibliotecas.Http;

public interface IClientFactoryPost
{
    Task<S> Post<S, E>(string endPoint, E model, Api api);
    Task Post<E>(string endPoint, E model, Api api);
}

public class ClientFactoryPost : IClientFactoryPost
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ClientFactoryPost(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<S?> Post<S, E>(string endPoint, E model, Api api)
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient(api.Url);

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", api.Token);
            
            string url = $"{api.Url}{endPoint}";

            httpClient.DefaultRequestHeaders.Accept.Clear();
            string strJson = JsonConvert.SerializeObject(model);
            StringContent httpContent = new(strJson, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await httpClient.PostAsync(url, httpContent))
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
                catch (Exception ex)
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

    public async Task Post<E>(string endPoint, E model, Api api)
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", api.Token);

            string url = $"{api.Url}{endPoint}";

            var settings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd'T'HH:mm:ss.fffZ",
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            StringContent httpContent = new(JsonConvert.SerializeObject(model), Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json);

            var json = JsonConvert.SerializeObject(model, settings);
            Console.WriteLine(json);

            using (HttpResponseMessage response = await httpClient.PostAsync(url, httpContent))
            {
                try
                {
                    response.EnsureSuccessStatusCode();
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
