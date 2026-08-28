using Microsoft.AspNetCore.Mvc;
using Auth.Servicos;
using Model.DTOs;

namespace Auth.Controllers;

[ApiController]
[Route("api/auth/usuario-modulo")]
public class UsuarioModuloController : ControllerBase
{
    private readonly IUsuarioModuloServicos _usuarioModuloServicos;

    public UsuarioModuloController(IUsuarioModuloServicos usuarioModuloServicos)
    {
        _usuarioModuloServicos = usuarioModuloServicos;
    }

    [HttpPost("atribuirModulo")]
    public async Task<IActionResult> AtribuirModulo(UsuarioModuloDTO dto)
    {
        await _usuarioModuloServicos.AtribuirModulo(dto);
        return Ok();
    }

    [HttpGet("listar-modulos-usuario/{usuarioId}")]
    public async Task<IActionResult> ListarModulosDoUsuario(Guid usuarioId)
    {
        var modulos = await _usuarioModuloServicos.ListarModulosDoUsuario(usuarioId);
        return Ok(modulos);
    }

    [HttpDelete("remover-modulo-usuario")]
    public async Task<IActionResult> RemoverModuloDoUsuario(Guid usuarioId, int moduloId)
    {
        await _usuarioModuloServicos.RemoverAcesso(usuarioId, moduloId);
        return Ok();
    }
}
