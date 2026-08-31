using Bibliotecas.Http;
using CrossCutting.Model.DTOs.Escolar.Aluno;
using Web.Areas.Escolar.Models.TabelaDinamica;

namespace Web.Areas.Escolar.Services;

public interface IAlunoServices
{
    Task Cadastrar(AlunoCadastroDTO pessoaCadastro, string? token);
    Task Atualizar(AlunoAtualizacaoDTO aluno, string? token);
    Task<List<AlunoTabela>> Listar(string? token);
    Task<AlunoRespostaDTO> Obter(int id, string? token);
    Task Deletar(Guid id, string? token);
}

public class AlunoServices(IClientFactory http) : IAlunoServices
{
    private readonly IClientFactory _http = http;

    public async Task Cadastrar(AlunoCadastroDTO pessoaCadastro, string? token)
    {
        await _http.Post("api/escolar/Aluno/cadastrar", pessoaCadastro, new Api { Token = token, Url = "https://localhost:44380/" });
    }

    public async Task Atualizar(AlunoAtualizacaoDTO aluno, string? token)
    {
        await _http.Put("api/escolar/Aluno/atualizacao", aluno, new Api { Token = token, Url = "https://localhost:44380/" });
    }

    public async Task<List<AlunoTabela>> Listar(string? token)
    {
        var ret = await _http.Get<List<AlunoRespostaDTO>>("api/escolar/Aluno/listar", new Api { Token = token, Url = "https://localhost:44380/" });

        var pessoas = AlunoTabela.MapearParaTabela(ret);
        return pessoas;
    }
    public async Task<AlunoRespostaDTO> Obter(int id, string? token)
    {
        return await _http.Get<AlunoRespostaDTO>($"api/escolar/Aluno/{id}", new Api { Token = token, Url = "https://localhost:44380/" });
    }

    public async Task Deletar(Guid id, string? token)
    {
        var ret = await _http.Delete<HttpResponse>($"api/escolar/Aluno/deletar?publicId={id}", new Api { Token = token, Url = "https://localhost:44380/" });
    }
}