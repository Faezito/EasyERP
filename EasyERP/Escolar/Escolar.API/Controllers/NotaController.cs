using CrossCutting.Model.DTOs.Escolar.Nota;
using Escolar.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Escolar.API.Controllers;

[ApiController]
[Route("api/escolar/[controller]")]
public class NotaController(INotaServicos notaServicos) : ControllerBase
{
    private readonly INotaServicos _notaServicos = notaServicos;

    [HttpGet("listar")]
    public async Task<IActionResult> Listar()
    {
        var notas = await _notaServicos.ObterTodosAsync();
        return Ok(notas);
    }

    [HttpGet("listar-notas-aluno/{alunoId}")]
    public async Task<IActionResult> ListarNotasDoAluno(int alunoId)
    {
        var notas = await _notaServicos.ListarPorAlunoId(alunoId);
        return Ok(notas);
    }

    [HttpGet("listar-notas-pessoaId/{pessoaId}")]
    public async Task<IActionResult> ListarNotasPorPessoaId(Guid pessoaId)
    {
        var notas = await _notaServicos.ListarPorPessoaId(pessoaId);
        return Ok(notas);
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar(NotaCadastroDTO notaDto)
    {
        await _notaServicos.Cadastrar(notaDto);
        return Ok();
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Atualizar(NotaAtualizacaoDTO notaDto)
    {
        await _notaServicos.Atualizar(notaDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        await _notaServicos.Excluir(id);
        return Ok();
    }
}
