//using Newtonsoft.Json;

//namespace Bibliotecas.Http;

//public interface IClientFactoryDelete
//{
//    Task<S?> Delete<S>(string endPoint, int apiId);
//}

//public class ClientFactoryDelete : IClientFactoryDelete
//{
//    private readonly IHttpClientFactory _httpClientFactory;
//    private readonly IAPIsServicos _api;

//    public ClientFactoryDelete(IHttpClientFactory httpClientFactory, IAPIsServicos api)
//    {
//        _httpClientFactory = httpClientFactory;
//        _api = api;
//    }

//    public async Task<S?> Delete<S>(string endPoint, int apiId)
//    {
//        var api = await _api.ObterPorCodigo(apiId);

//        var httpClient = _httpClientFactory.CreateClient();
//        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-API-Key", api.Token);

//        string url = $"{api.Url}{endPoint}";

//        using HttpResponseMessage response = await httpClient.DeleteAsync(url);

//        try
//        {
//            response.EnsureSuccessStatusCode();

//            string json = await response.Content.ReadAsStringAsync();

//            return string.IsNullOrWhiteSpace(json)
//                ? default
//                : JsonConvert.DeserializeObject<S>(json);
//        }
//        catch (HttpRequestException)
//        {
//            throw await ExceptionCustom.Exception(response);
//        }
//    }
//}