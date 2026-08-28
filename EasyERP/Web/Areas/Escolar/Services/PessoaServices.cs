using Bibliotecas.Http;
using Model.DTOs.Escolar.Pessoa;
using Web.Areas.Escolar.Models.TabelaDinamica;

namespace Web.Areas.Escolar.Services;

public interface IPessoaServices
{
    Task Cadastrar(PessoaCadastroDTO pessoaCadastro, string? token);
    Task Atualizar(PessoaAtualizacaoDTO pessoa, string? token);
    Task<List<PessoaTabela>> Listar(string? token);
    Task<PessoaRespostaDTO> Obter(Guid id, string? token);
    Task Deletar(Guid id, string? token);
}

public class PessoaServices(IClientFactory http) : IPessoaServices
{
    private readonly IClientFactory _http = http;

    public async Task Cadastrar(PessoaCadastroDTO pessoaCadastro, string? token)
    {
        await _http.Post("api/escolar/Pessoa/cadastro", pessoaCadastro, new Api { Token = token, Url = "https://localhost:44380/" });
    }

    public async Task Atualizar(PessoaAtualizacaoDTO pessoa, string? token)
    {
        await _http.Put("api/escolar/Pessoa/atualizacao", pessoa, new Api { Token = token, Url = "https://localhost:44380/" });
    }

    public async Task<List<PessoaTabela>> Listar(string? token)
    {
        var ret = await _http.Get<List<PessoaRespostaDTO>>("api/escolar/Pessoa/listar", new Api { Token = token, Url = "https://localhost:44380/" });

        var pessoas = PessoaTabela.MapearParaTabela(ret);
        return pessoas;
    }
    public async Task<PessoaRespostaDTO> Obter(Guid id, string? token)
    {
        return await _http.Get<PessoaRespostaDTO>($"api/escolar/Pessoa/{id}", new Api { Token = token, Url = "https://localhost:44380/" });
    }

    public async Task Deletar(Guid id, string? token)
    {
        var ret = await _http.Delete<HttpResponse>($"api/escolar/Pessoa/deletar?publicId={id}", new Api { Token = token, Url = "https://localhost:44380/" });
    }
}