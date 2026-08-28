using Bibliotecas.Http;
using Model.DTOs.Escolar.Pessoa;
using Web.Areas.Escolar.Models.TabelaDinamica;

namespace Web.Areas.Escolar.Services;

public interface IPessoaServices
{
    Task Cadastrar(PessoaCadastroDTO pessoaCadastro);
    Task Atualizar(PessoaAtualizacaoDTO pessoa);
    Task<List<PessoaTabela>> Listar();
    Task<PessoaRespostaDTO> Obter(Guid id);
    Task Deletar(Guid id);
}

public class PessoaServices(IClientFactory http) : IPessoaServices
{
    private readonly IClientFactory _http = http;

    public async Task Cadastrar(PessoaCadastroDTO pessoaCadastro)
    {
        await _http.Post("api/escolar/Pessoa/cadastro", pessoaCadastro, new Api { Url = "https://localhost:44380/" });
    }

    public async Task Atualizar(PessoaAtualizacaoDTO pessoa)
    {
        await _http.Put("api/escolar/Pessoa/atualizacao", pessoa, new Api { Url = "https://localhost:44380/" });
    }

    public async Task<List<PessoaTabela>> Listar()
    {
        var ret = await _http.Get<List<PessoaRespostaDTO>>("api/escolar/Pessoa/listar", new Api { Url = "https://localhost:44380/" });

        var pessoas = PessoaTabela.MapearParaTabela(ret);
        return pessoas;
    }
    public async Task<PessoaRespostaDTO> Obter(Guid id)
    {
        return await _http.Get<PessoaRespostaDTO>($"api/escolar/Pessoa/{id}", new Api { Url = "https://localhost:44380/" });
    }

    public async Task Deletar(Guid id)
    {
        var ret = await _http.Delete<HttpResponse>($"api/escolar/Pessoa/deletar?publicId={id}", new Api { Url = "https://localhost:44380/" });
    }
}