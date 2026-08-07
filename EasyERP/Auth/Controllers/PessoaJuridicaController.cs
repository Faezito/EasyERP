using Auth.Servicos;
using CrossCutting.Model.DTOs.PessoaJuridica;
using Microsoft.AspNetCore.Mvc;

namespace AvenTuristaAPI.Controllers
{
    [ApiController]
    [Route("api/auth/pessoajuridica")]
    public class PessoaJuridicaController : ControllerBase
    {
        private readonly IPessoaJuridicaServicos _pessoaJuridicaServicos;
        public PessoaJuridicaController(IPessoaJuridicaServicos pessoaJuridicaServicos)
        {
            _pessoaJuridicaServicos = pessoaJuridicaServicos;
        }

        [HttpGet("{publicId}")]
        public async Task<IActionResult> Obter(Guid publicId)
        {
            var empresa = await _pessoaJuridicaServicos.ObterPorId(publicId) ?? throw new Exception("Empresa não encontrada");
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

        [HttpPost("cadastroBulk")]
        public async Task<IActionResult> CadastroBulk(List<PessoaJuridicaCadastroDTO> dtos)
        {
            await _pessoaJuridicaServicos.CadastrarBulk(dtos);
            return Ok();
        }

        [HttpPut("atualizacao")]
        public async Task<IActionResult> Atualizacao(PessoaJuridicaAlteracaoDTO dto)
        {
            await _pessoaJuridicaServicos.Atualizacao(dto);
            return Ok();
        }

        [HttpDelete("deletar")]
        public async Task<IActionResult> Deletar(Guid publicId)
        {
            await _pessoaJuridicaServicos.Deletar(publicId);
            return Ok();
        }
    }
}
