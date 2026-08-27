using Microsoft.AspNetCore.Mvc;
using Auth.Servicos;
using Auth.Repositorio.Entidades;
using Model.DTOs;

namespace AvenTuristaAPI.Controllers
{
    [ApiController]
    [Route("api/auth/modulo")]
    public class ModuloController : ControllerBase
    {
        private readonly IModuloServicos _moduloServicos;

        public ModuloController(IModuloServicos moduloServicos)
        {
            _moduloServicos = moduloServicos;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            var modulo = await _moduloServicos.ListarTodos();
            if (modulo == null)
                return NotFound();

            return Ok(modulo);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var modulos = await _moduloServicos.ObterTodosAsync();
            return Ok(modulos);
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastro(Modulo modulo)
        {
            await _moduloServicos.Cadastrar(modulo);
            return Ok();
        }

        [HttpPut("atualizacao")]
        public async Task<IActionResult> Atualizacao(Modulo modulo)
        {
            await _moduloServicos.Atualizar(modulo);
            return Ok();
        }

        [HttpDelete("deletar")]
        public async Task<IActionResult> Deletar(int id)
        {
            await _moduloServicos.RemoverAsync(new Modulo { Id = id });
            return Ok();
        }

        [HttpPost("atribuirModulo")]
        public async Task<IActionResult> AtribuirModulo(UsuarioModuloDTO dto)
        {
            await _moduloServicos.AtribuirModulo(dto);

            return Ok();
        }
    }
}
