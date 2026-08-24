using Bibliotecas.Http;
using CrossCutting.Model.DTOs.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Web.Services;

public interface IAcessoServices
{
    Task<ClaimsPrincipal> Login(LoginRequestDTO login);
}

public class AcessoServices(IClientFactoryPost post) : IAcessoServices
{
    private readonly IClientFactoryPost _post = post;
    public async Task<ClaimsPrincipal> Login(LoginRequestDTO login)
    {
        var res = await _post.Post<LoginResponseDTO, LoginRequestDTO>("api/auth/acesso/login", login, new Api { Url = "https://localhost:44380/" });
        var claims = CriarClaims(res);

        return claims;
    }

    private ClaimsPrincipal CriarClaims(LoginResponseDTO dto)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, dto.Usuario.PublicId.ToString()),
            new Claim(ClaimTypes.Role, dto.Usuario.Perfil.ToString()),
            new Claim(ClaimTypes.Name, dto.Usuario.NomeUsuario.ToString()),
            new Claim("NomeCompleto", dto.Usuario.Pessoa!.NomeCompleto),
        };

        var identidade = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identidade);

        var properties = new AuthenticationProperties
        {
            IsPersistent = true
        };
        properties.StoreTokens(new[]
        {
            new AuthenticationToken
            {
                Name = "access_token",
                Value = dto.Token
            }
        });

        return principal;
    }
}