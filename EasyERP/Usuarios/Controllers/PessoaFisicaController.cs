using Microsoft.AspNetCore.Mvc;
using Usuarios.Model.DTOs;
using Usuarios.Servicos;

namespace AvenTuristaAPI.Controllers
{
    [ApiController]
    [Route("api/usuario")]
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
            var usuario = await _pessoaServicos.ObterUsuarioPorId(usuarioId) ?? throw new Exception("Usuario não encontrado");
            return Ok(usuario);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var usuarios = await _pessoaServicos.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastro(UsuarioCadastroDTO dto)
        {
            await _pessoaServicos.Cadastro(dto);
            return Ok();
        }

        [HttpPut("atualizacao")]
        public async Task<IActionResult> Atualizacao(UsuarioAtualizacaoDTO dto)
        {
            await _pessoaServicos.Atualizacao(dto);
            return Ok();
        }

        [HttpDelete("deletar")]
        public async Task<IActionResult> Deletar(int pessoaId)
        {
            await _pessoaServicos.Deletar(pessoaId);
            return Ok();
        }
    }
}
