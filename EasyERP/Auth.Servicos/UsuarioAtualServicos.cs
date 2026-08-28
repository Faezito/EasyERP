using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Auth.Servicos;

public interface IUsuarioAtualServicos
{
    int UsuarioId { get; }
    string? Perfil { get; }
}

public class UsuarioAtualServicos : IUsuarioAtualServicos
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UsuarioAtualServicos(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int UsuarioId
    {
        get
        {
            var valor = _httpContextAccessor.HttpContext?
                .User
                .FindFirst(ClaimTypes.NameIdentifier)?
                .Value;

            return int.TryParse(valor, out var id) ? id : 0;
        }
    }

    public string? Perfil =>
        _httpContextAccessor.HttpContext?
            .User
            .FindFirst(ClaimTypes.Role)?
            .Value;
}