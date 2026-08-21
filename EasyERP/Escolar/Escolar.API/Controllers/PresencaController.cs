using CrossCutting.Model.DTOs.Escolar.Presenca;
using Escolar.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Escolar.API.Controllers;

[ApiController]
[Route("api/escolar/[controller]")]
public class PresencaController(IPresencaServicos presencaServicos) : ControllerBase
{
    private readonly IPresencaServicos _presencaServicos = presencaServicos;

    [HttpGet("listar")]
    public async Task<IActionResult> Listar()
    {
        var presencas = await _presencaServicos.ObterTodosAsync();
        return Ok(presencas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Obter(int id)
    {
        var presencas = await _presencaServicos.ObterPorIdAsync(id);
        return Ok(presencas);
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar(PresencaCadastroDTO presencaDto)
    {
        await _presencaServicos.Cadastrar(presencaDto);
        return Ok();
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Atualizar(PresencaAtualizacaoDTO presencaDto)
    {
        await _presencaServicos.Atualizar(presencaDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        await _presencaServicos.Excluir(id);
        return Ok();
    }
}
