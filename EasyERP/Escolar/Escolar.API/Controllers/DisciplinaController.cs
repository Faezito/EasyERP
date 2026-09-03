using Escolar.Servicos;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs.Escolar.Disciplina;

namespace Escolar.API.Controllers;

[ApiController]
[Route("api/escolar/[controller]")]
public class DisciplinaController(IDisciplinaServicos disciplinaServicos) : ControllerBase
{
    private readonly IDisciplinaServicos _disciplinaServicos = disciplinaServicos;

    [HttpGet("{id}")]
    public async Task<IActionResult> Obter(int id) 
    {
        var disciplina = await _disciplinaServicos.ObterPorId(id);
        return Ok(disciplina);
    }

    [HttpGet("listar/{pessoaJuridicaId}")]
    public async Task<IActionResult> Listar(int pessoaJuridicaId)
    {
        var disciplinas = await _disciplinaServicos.Listar(pessoaJuridicaId);
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
