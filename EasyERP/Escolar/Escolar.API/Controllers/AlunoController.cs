using CrossCutting.Model.DTOs.Escolar.Aluno;
using Escolar.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Escolar.API.Controllers;

[ApiController]
[Route("api/escolar/[controller]")]
public class AlunoController(IAlunoServicos alunoServicos) : ControllerBase
{
    private readonly IAlunoServicos _alunoServicos = alunoServicos;

    [HttpGet("listar")]
    public async Task<IActionResult> Listar()
    {
        var alunos = await _alunoServicos.ObterTodosAsync();
        return Ok(alunos);
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar(AlunoCadastroDTO alunoDto)
    {
        await _alunoServicos.Cadastro(alunoDto);
        return Ok();
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Atualizar(AlunoAtualizacaoDTO alunoDto)
    {
        await _alunoServicos.Atualizacao(alunoDto);
        return Ok();
    }

    [HttpDelete("{publicId}")]
    public async Task<IActionResult> Deletar(Guid publicId)
    {
        await _alunoServicos.Excluir(publicId);
        return Ok();
    }
}