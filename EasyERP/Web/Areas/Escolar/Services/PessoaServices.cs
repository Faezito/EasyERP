using Bibliotecas.Http;
using Model.DTOs.Escolar.Pessoa;
using Web.Areas.Escolar.Models.TabelaDinamica;

namespace Web.Areas.Escolar.Services;

public interface IPessoaServices
{
    Task Cadastrar(PessoaCadastroDTO pessoaCadastro, string? token);
    Task<List<PessoaTabela>> Listar(string? token);
    Task<PessoaRespostaDTO> Obter(Guid id, string? token);
    Task Deletar(Guid id, string? token);
}

public class PessoaServices(IClientFactoryPost post, IClientFactoryGet get, IClientFactoryDelete delete) : IPessoaServices
{
    private readonly IClientFactoryPost _post = post;
    private readonly IClientFactoryGet _get = get;
    private readonly IClientFactoryDelete _delete = delete;

    public async Task Cadastrar(PessoaCadastroDTO pessoaCadastro, string? token)
    {
        await _post.Post("api/escolar/Pessoa/cadastro", pessoaCadastro, new Api { Token = token, Url = "https://localhost:44380/" });
    }

    public async Task<List<PessoaTabela>> Listar(string? token)
    {
        var ret = await _get.Get<List<PessoaRespostaDTO>>("api/escolar/Pessoa/listar", new Api { Token = token, Url = "https://localhost:44380/" });

        var pessoas = PessoaTabela.MapearParaTabela(ret);
        return pessoas;
    }
    public async Task<PessoaRespostaDTO> Obter(Guid id, string? token)
    {
        return await _get.Get<PessoaRespostaDTO>($"api/escolar/Pessoa/{id}", new Api { Token = token, Url = "https://localhost:44380/" });
    }

    public async Task Deletar(Guid id, string? token)
    {
        var ret = await _delete.Delete<HttpResponse>($"api/escolar/Pessoa/deletar?publicId={id}", new Api { Token = token, Url = "https://localhost:44380/" });
    }
}