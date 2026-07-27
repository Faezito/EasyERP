using Microsoft.AspNetCore.Mvc;
using Model.DTOs.Endereco;
using Auth.Repositorio.Entidades;
using Auth.Servicos;

namespace AvenTuristaAPI.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/endereco")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoServicos _servicoDeEndereco;
        public EnderecoController(IEnderecoServicos servicoDeEndereco)
        {
            _servicoDeEndereco = servicoDeEndereco;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            var endereco = await _servicoDeEndereco.ObterPorIdAsync(id);
            return Ok(endereco);
        }

        [HttpGet("listarPorEmpresa/{empresaId}")]
        public async Task<IActionResult> ListarPorEmpresa(int empresaId)
        {
            var endereco = await _servicoDeEndereco.ObterPorIdAsync(empresaId);
            return Ok(endereco);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var locais = await _servicoDeEndereco.ObterTodosAsync();
            return Ok(locais);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar(EnderecoCadastroDTO dto)
        {
            await _servicoDeEndereco.Inserir(dto);
            return Ok();
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> Atualizar(EnderecoAtualizacaoDTO dto)
        {
            await _servicoDeEndereco.AtualizarAsync(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Deletar(int id)
        {
            await _servicoDeEndereco.RemoverAsync(new Endereco { Id = id });
            return Ok();
        }
    }
}
