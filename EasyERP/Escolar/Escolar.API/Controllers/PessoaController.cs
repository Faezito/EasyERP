using Escolar.Servicos;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs.Escolar.Pessoa;

namespace AvenTuristaAPI.Controllers;

[ApiController]
[Route("api/escolar/[controller]")]
public class PessoaController : ControllerBase
{
    private readonly IPessoaServicos _pessoaServicos;
    public PessoaController(IPessoaServicos pessoaServicos)
    {
        _pessoaServicos = pessoaServicos;
    }

    [HttpGet("{publicId}")]
    public async Task<IActionResult> Obter(Guid publicId)
    {
        var pessoa = await _pessoaServicos.ObterPorPublicId(publicId);
        return Ok(pessoa);
    }

    [HttpGet("listar")]
    public async Task<IActionResult> Listar()
    {
        var usuarios = await _pessoaServicos.Listar();
        return Ok(usuarios);
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> Cadastro(PessoaCadastroDTO dto)
    {
        await _pessoaServicos.Cadastrar(dto);
        return Ok();
    }

    [HttpPost("cadastroBulk")]
    public async Task<IActionResult> CadastroBulk(List<PessoaCadastroDTO> dtos)
    {
        await _pessoaServicos.CadastrarBulk(dtos);
        return Ok();
    }

    [HttpPut("atualizacao")]
    public async Task<IActionResult> Atualizacao(PessoaAtualizacaoDTO dto)
    {
        await _pessoaServicos.Atualizar(dto);
        return Ok();
    }

    [HttpDelete("deletar")]
    public async Task<IActionResult> Deletar(Guid publicId)
    {
        await _pessoaServicos.Deletar(publicId);
        return Ok();
    }
}
