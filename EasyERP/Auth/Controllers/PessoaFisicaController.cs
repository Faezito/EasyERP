using Microsoft.AspNetCore.Mvc;
using Model.DTOs.PessoaFisica;
using Auth.Servicos;

namespace AvenTuristaAPI.Controllers
{
    [ApiController]
    [Route("api/auth/[controller]")]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly IPessoaFisicaServicos _pessoaServicos;
        public PessoaFisicaController(IPessoaFisicaServicos pessoaServicos)
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
        public async Task<IActionResult> Cadastro(PessoaFisicaCadastroDTO dto)
        {
            await _pessoaServicos.Cadastrar(dto);
            return Ok();
        }

        [HttpPost("cadastroBulk")]
        public async Task<IActionResult> CadastroBulk(List<PessoaFisicaCadastroDTO> dtos)
        {
            await _pessoaServicos.CadastrarBulk(dtos);
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
