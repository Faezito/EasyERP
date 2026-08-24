using Auth.Servicos;
using CrossCutting.Model.DTOs.Login;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers;

[ApiController]
[Route("api/auth/acesso")]
public class AcessoController(IAcessoServicos acessoServicos) : ControllerBase
{
    private readonly IAcessoServicos _acessoServicos = acessoServicos;

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDTO dto)
    {
        var login = await _acessoServicos.Login(dto);
        return Ok(login);
    }
}