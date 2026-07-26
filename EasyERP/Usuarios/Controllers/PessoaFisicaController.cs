using Microsoft.AspNetCore.Mvc;
using Model.DTOs.PessoaFisica;
using Usuarios.Servicos;

namespace AvenTuristaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly IPessoaFisicaServicos _pessoaServicos;
        public PessoaFisicaController(IPessoaFisicaServicos pessoaServicos)
        {
            _pessoaServicos = pessoaServicos;
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> Obter(int usuarioId)
        {
            return Ok();
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var usuarios = await _pessoaServicos.Listar();
            return Ok(usuarios);
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastro(PessoaFisicaCadastroDTO dto)
        {
            await _pessoaServicos.Cadastrar(dto);
            return Ok();
        }

        [HttpPut("atualizacao")]
        public async Task<IActionResult> Atualizacao(PessoaFisicaAtualizacaoDTO dto)
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
}
