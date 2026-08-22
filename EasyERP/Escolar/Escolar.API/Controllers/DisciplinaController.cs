using Escolar.Servicos;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs.Escolar.Disciplina;

namespace Escolar.API.Controllers;

[ApiController]
[Route("api/escolar/[controller]")]
public class DisciplinaController(IDisciplinaServicos disciplinaServicos) : ControllerBase
{
    private readonly IDisciplinaServicos _disciplinaServicos = disciplinaServicos;

    [HttpGet("listar")]
    public async Task<IActionResult> Listar()
    {
        var disciplinas = await _disciplinaServicos.ObterTodosAsync();
        return Ok(disciplinas);
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar(DisciplinaCadastroDTO disciplinaDto)
    {
        await _disciplinaServicos.Cadastrar(disciplinaDto);
        return Ok();
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Atualizar(DisciplinaAtualizacaoDTO disciplinaDto)
    {
        await _disciplinaServicos.Atualizar(disciplinaDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        await _disciplinaServicos.Excluir(id);
        return Ok();
    }
}
