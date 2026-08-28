using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Bibliotecas.Http;

public interface IClientFactory
{
    Task<S> Get<S>(string endPoint, Api api);
    Task<S?> Delete<S>(string endPoint, Api api);
    Task<S?> Put<T, S>(string endPoint, T body, Api api);
    Task Put<T>(string endPoint, T body, Api api);
    Task<S> Post<S, E>(string endPoint, E model, Api api);
    Task Post<E>(string endPoint, E model, Api api);


}

public class ClientFactory : IClientFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ClientFactory(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
    {
        _httpClientFactory = httpClientFactory;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<S?> Delete<S>(string endPoint, Api api)
    {
        var token = await ObterToken();

        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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
            await ExceptionCustom.Exception(response);
            return default;
        }
    }

    public async Task<S?> Put<T, S>(string endPoint, T body, Api api)
    {
        var token = await ObterToken();

        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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
            await ExceptionCustom.Exception(response);
            return default;
        }
    }

    public async Task Put<T>(string endPoint, T body, Api api)
    {
        var token = await ObterToken();

        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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
            await ExceptionCustom.Exception(response);
        }
    }

    public async Task<S> Post<S, E>(string endPoint, E model, Api api)
    {
        var token = await ObterToken();

        var httpClient = _httpClientFactory.CreateClient(api.Url);

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

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
                await ExceptionCustom.Exception(response);
                return default;
            }
        }
    }

    public async Task Post<E>(string endPoint, E model, Api api)
    {
        var token = await ObterToken();

        var httpClient = _httpClientFactory.CreateClient();

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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
                await ExceptionCustom.Exception(response);
            }
        }
    }

    public async Task<S> Get<S>(string endPoint, Api api)
    {
        var token = await ObterToken();

        var httpClient = _httpClientFactory.CreateClient(api.Url);

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

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
                await ExceptionCustom.Exception(response);
                return default;
            }
        }
    }


    private async Task<string?> ObterToken()
    {
        var result = await _httpContextAccessor.HttpContext!
        .AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        var token = result.Properties?.GetTokenValue("access_token");
        return token;
    }
}