using Admin.Repositorio.Entidades;
using Admin.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Admin.API.Controllers;

[ApiController]
[Route("api/admin/[controller]")]
public class ApiExternaController(IApiExternaServicos apiExternaServicos) : ControllerBase
{
    private readonly IApiExternaServicos _apiExternaServicos = apiExternaServicos;

    [HttpGet("{apiId}")]
    public async Task<IActionResult> Obter(int apiId)
    {
        var api = await _apiExternaServicos.ObterPorIdAsync(apiId);
        return Ok(api);
    }

    [HttpGet("listar")]
    public async Task<IActionResult> Listar()
    {
        var apis = await _apiExternaServicos.ObterTodosAsync();
        return Ok(apis);
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar(ApiExterna api)
    {
        await _apiExternaServicos.AdicionarAsync(api);
        return Ok(api);
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Atualizar(ApiExterna api)
    {
        await _apiExternaServicos.AtualizarAsync(api);
        return Ok(api);
    }

    [HttpDelete("{apiId}")]
    public async Task<IActionResult> Excluir(int apiId)
    {
        await _apiExternaServicos.RemoverAsync(new ApiExterna { Id = apiId });
        return Ok();
    }
}
