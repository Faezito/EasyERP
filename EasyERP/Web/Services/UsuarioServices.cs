using Bibliotecas.Http;
using Model.DTOs.Usuario;

namespace Web.Services;

public interface IUsuarioServices
{
    Task Cadastrar(UsuarioCadastroDTO usuario);
    Task Atualizar(UsuarioAtualizacaoDTO usuario);
    Task<List<UsuarioRespostaDTO>> Listar();
    Task<UsuarioRespostaDTO> Obter(Guid publicId);
    Task Deletar(Guid publicId);
}

public class UsuarioServices(IClientFactory http) : IUsuarioServices
{
    private readonly IClientFactory _http = http;
    private readonly Api _apiConfig = new() { Url = "https://localhost:44380/" };

    public async Task Cadastrar(UsuarioCadastroDTO usuario)
    {
        await _http.Post("api/auth/usuario/cadastro", usuario, _apiConfig);
    }

    public async Task Atualizar(UsuarioAtualizacaoDTO usuario)
    {
        await _http.Put("api/auth/usuario/atualizacao", usuario, _apiConfig);
    }

    public async Task<List<UsuarioRespostaDTO>> Listar()
    {
        return await _http.Get<List<UsuarioRespostaDTO>>("api/auth/usuario/listar", _apiConfig);
    }

    public async Task<UsuarioRespostaDTO> Obter(Guid publicId)
    {
        return await _http.Get<UsuarioRespostaDTO>($"api/auth/usuario/{publicId}", _apiConfig);
    }

    public async Task Deletar(Guid publicId)
    {
        await _http.Delete<HttpResponse>($"api/auth/usuario/deletar?publicId={publicId}", _apiConfig);
    }
}
