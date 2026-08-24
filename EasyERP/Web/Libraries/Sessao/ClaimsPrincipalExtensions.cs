using CrossCutting.Model.Enums;
using Microsoft.AspNetCore.Authentication;
using Model.DTOs.PessoaFisica;
using Model.DTOs.Usuario;
using System.Security.Claims;

namespace Web.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal user)
    {
        var claim = user?.FindFirst(ClaimTypes.NameIdentifier);

        if (claim == null)
        {
            try
            {
                var http = new HttpContextAccessor();
                http.HttpContext?.SignOutAsync("CookieAuth");
            }
            catch { }

            return new Guid("000-000");
        }

        if (!Guid.TryParse(claim.Value, out Guid id))
            return new Guid("000-000");

        return id;
    }

    public static string GetUserTipo(this ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Role)?.Value;
    }

    public static string GetUserEmail(this ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Email)?.Value;
    }

    public static string GetUserName(this ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Name)?.Value;
    }

    public static string ObterNomeCompleto(this ClaimsPrincipal user)
    {
        return user.FindFirst("NomeCompleto")?.Value;
    }

    public static bool GetSenhaTemp(this ClaimsPrincipal user)
    {
        var _temp = user.FindFirst("senhaTemporaria")?.Value;
        if (string.IsNullOrEmpty(_temp))
            return false;

        return (bool)Convert.ChangeType(_temp, typeof(bool));
    }

    public static UsuarioRespostaDTO ObterUsuario(this ClaimsPrincipal user)
    {
        var id = GetUserId(user);
        var tipo = GetUserTipo(user);
        string email = GetUserEmail(user);
        string nome = GetUserName(user);

        if (!Enum.TryParse<Perfil>(tipo, out var perfil))
        {
            throw new InvalidOperationException("Perfil do usuário não informado ou inválido.");
        }

        var usuario = new UsuarioRespostaDTO
        {
            PublicId = id,
            Perfil = perfil,
            Pessoa = new PessoaFisicaRespostaDTO
            {
                Email = email,
                NomeCompleto = nome,
            }
        };
        return usuario;
    }
}
