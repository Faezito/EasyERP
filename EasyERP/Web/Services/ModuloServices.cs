using Bibliotecas.Http;
using Model.DTOs;
using Web.Models.TabelaDinamica;

namespace Web.Services;

public interface IModuloServices
{
    Task Cadastrar(ModuloCadastroDTO modulo);
    Task Atualizar(ModuloDTO modulo);
    Task<List<ModuloDTO>> Listar();
    Task<ModuloDTO> Obter(int id);
    Task Deletar(int id);
}

public class ModuloServices(IClientFactory http) : IModuloServices
{
    private readonly IClientFactory _http = http;

    public async Task Cadastrar(ModuloCadastroDTO modulo)
    {
        await _http.Post("api/auth/modulo/cadastro", modulo, new Api { Url = "https://localhost:44380/" });
    }

    public async Task Atualizar(ModuloDTO modulo)
    {
        await _http.Put("api/auth/modulo/atualizacao", modulo, new Api { Url = "https://localhost:44380/" });
    }

    public async Task<List<ModuloDTO>> Listar()
    {
        return await _http.Get<List<ModuloDTO>>("api/auth/modulo/listar", new Api { Url = "https://localhost:44380/" });
    }

    public async Task<ModuloDTO> Obter(int id)
    {
        return await _http.Get<ModuloDTO>($"api/auth/modulo/{id}", new Api { Url = "https://localhost:44380/" });
    }

    public async Task Deletar(int id)
    {
        await _http.Delete<HttpResponse>($"api/auth/modulo/deletar?id={id}", new Api { Url = "https://localhost:44380/" });
    }
}
