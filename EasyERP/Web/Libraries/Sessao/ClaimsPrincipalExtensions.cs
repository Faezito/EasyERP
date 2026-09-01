using CrossCutting.Model.Enums;
using Microsoft.AspNetCore.Authentication;
using Model.DTOs;
using Model.DTOs.PessoaFisica;
using Model.DTOs.Usuario;
using Newtonsoft.Json;
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
            PessoaFisica = new PessoaFisicaRespostaDTO
            {
                Email = email,
                NomeCompleto = nome,
            }
        };
        return usuario;
    }

    public static List<int> ObterAcessos(this ClaimsPrincipal user)
    {
        var modulosString = user.FindFirst("Modulos")?.Value ?? string.Empty;
        List<int> modulos = modulosString
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        return modulos;
    }

    public static List<ModuloDTO> ObterModulosDoUsuario(this ClaimsPrincipal user)
    {
        var modulosJson = user.FindFirst("ModuloDTOs")?.Value ?? string.Empty;
        var modulos = JsonConvert.DeserializeObject<List<ModuloDTO>>(modulosJson);
        return modulos ?? new();
    }
}
