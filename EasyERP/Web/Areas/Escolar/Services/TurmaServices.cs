using Bibliotecas.Http;
using Model.DTOs.Escolar.Turma;

namespace Web.Areas.Escolar.Services;

public interface ITurmaServices
{
    Task Cadastrar(TurmaDTO dto);
    Task Atualizar(TurmaDTO dto);
    Task<List<TurmaDTO>> Listar();
    Task<TurmaDTO> Obter(int id);
    Task Deletar(int id);
}

public class TurmaServices(IClientFactory http) : ITurmaServices
{
    private readonly IClientFactory _http = http;

    public async Task Cadastrar(TurmaDTO dto)
    {
        await _http.Post("api/escolar/Turma/cadastrar", dto, new Api { Url = "https://localhost:44380/" });
    }

    public async Task Atualizar(TurmaDTO dto)
    {
        await _http.Put("api/escolar/Turma/atualizar", dto, new Api { Url = "https://localhost:44380/" });
    }

    public async Task<List<TurmaDTO>> Listar()
    {
        return await _http.Get<List<TurmaDTO>>("api/escolar/Turma/listar", new Api { Url = "https://localhost:44380/" });
    }

    public async Task<TurmaDTO> Obter(int id)
    {
        return await _http.Get<TurmaDTO>($"api/escolar/Turma/{id}", new Api { Url = "https://localhost:44380/" });
    }

    public async Task Deletar(int id)
    {
        await _http.Delete<HttpResponse>($"api/escolar/Turma/{id}", new Api { Url = "https://localhost:44380/" });
    }
}
