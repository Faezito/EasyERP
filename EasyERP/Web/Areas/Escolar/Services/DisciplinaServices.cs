using Bibliotecas.Http;
using Model.DTOs.Escolar.Disciplina;

namespace Web.Areas.Escolar.Services;

public interface IDisciplinaServices
{
    Task Cadastrar(DisciplinaCadastroDTO disciplina);
    Task Atualizar(DisciplinaAtualizacaoDTO disciplina);
    Task<List<DisciplinaRespostaDTO>> Listar(int pessoaJuridicaId);
    Task<DisciplinaRespostaDTO> Obter(int id);
    Task Deletar(int id);
}

public class DisciplinaServices(IClientFactory http) : IDisciplinaServices
{
    private readonly IClientFactory _http = http;

    public async Task Cadastrar(DisciplinaCadastroDTO disciplina)
    {
        await _http.Post("api/escolar/disciplina/cadastrar", disciplina, new Api { Url = "https://localhost:44380/" });
    }

    public async Task Atualizar(DisciplinaAtualizacaoDTO disciplina)
    {
        await _http.Put("api/escolar/disciplina/atualizar", disciplina, new Api { Url = "https://localhost:44380/" });
    }

    public async Task<List<DisciplinaRespostaDTO>> Listar(int pessoaJuridicaId)
    {
        return await _http.Get<List<DisciplinaRespostaDTO>>($"api/escolar/disciplina/listar/{pessoaJuridicaId}", new Api { Url = "https://localhost:44380/" });
    }

    public async Task<DisciplinaRespostaDTO> Obter(int id)
    {
        return await _http.Get<DisciplinaRespostaDTO>($"api/escolar/disciplina/{id}", new Api { Url = "https://localhost:44380/" });
    }

    public async Task Deletar(int id)
    {
        await _http.Delete<HttpResponse>($"api/escolar/disciplina/{id}", new Api { Url = "https://localhost:44380/" });
    }
}
