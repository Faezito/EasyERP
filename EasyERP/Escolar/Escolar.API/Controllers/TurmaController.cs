using Escolar.Servicos;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs.Escolar.Turma;

namespace Escolar.API.Controllers;

[ApiController]
[Route("api/escolar/[controller]")]
public class TurmaController(ITurmaServicos turmaServicos) : ControllerBase
{
    private readonly ITurmaServicos turmaServicos = turmaServicos;

    [HttpGet("{turmaId}")]
    public async Task<IActionResult> Obter(int turmaId)
    {
        var turma = await turmaServicos.ObterPorIdAsync(turmaId);
        return Ok(turma);
    }

    [HttpGet("listar")]
    public async Task<IActionResult> Listar()
    {
        var turmas = await turmaServicos.ObterTodosAsync();
        return Ok(turmas);
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar(TurmaDTO dto)
    {
        await turmaServicos.Cadastrar(dto);
        return Ok();
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Atualizar(TurmaDTO dto)
    {
        await turmaServicos.Atualizar(dto);
        return Ok();
    }

    [HttpDelete("{turmaId}")]
    public async Task<IActionResult> Deletar(int turmaId)
    {
        await turmaServicos.RemoverAsync(new Repositorio.Entidades.Turma { Id = turmaId });
        return Ok();
    }
}
