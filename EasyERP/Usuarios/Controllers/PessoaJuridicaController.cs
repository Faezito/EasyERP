using Microsoft.AspNetCore.Mvc;
using Usuarios.Model.DTOs;
using Usuarios.Servicos;

namespace AvenTuristaAPI.Controllers
{
    [ApiController]
    [Route("api/pessoajuridica")]
    public class PessoaJuridicaController : ControllerBase
    {
        private readonly IPessoaJuridicaServicos _pessoaJuridicaServicos;
        public PessoaJuridicaController(IPessoaJuridicaServicos pessoaJuridicaServicos)
        {
            _pessoaJuridicaServicos = pessoaJuridicaServicos;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            var empresa = await _pessoaJuridicaServicos.ObterEmpresaPorId(id) ?? throw new Exception("Usuario não encontrado");
            return Ok(empresa);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var empresas = await _pessoaJuridicaServicos.ListarEmpresas();
            return Ok(empresas);
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastro(PessoaJuridicaCadastroDTO dto)
        {
            await _pessoaJuridicaServicos.Cadastro(dto);
            return Ok();
        }

        [HttpPut("atualizacao")]
        public async Task<IActionResult> Atualizacao(PessoaJuridicaAlteracaoDTO dto)
        {
            await _pessoaJuridicaServicos.Atualizacao(dto);
            return Ok();
        }

        [HttpDelete("deletar")]
        public async Task<IActionResult> Deletar(int id)
        {
            await _pessoaJuridicaServicos.Deletar(id);
            return Ok();
        }
    }
}
