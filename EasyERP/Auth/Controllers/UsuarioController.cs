using Microsoft.AspNetCore.Mvc;
using Model.DTOs.Usuario;
using Auth.Servicos;

namespace Auth.Controllers
{
    [ApiController]
    [Route("api/auth/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicos _usuarioServicos;
        public UsuarioController(IUsuarioServicos usuarioServicos)
        {
            _usuarioServicos = usuarioServicos;
        }

        [HttpGet("{publicId}")]
        public async Task<IActionResult> Obter(Guid publicId)
        {
            var usuario = await _usuarioServicos.ObterPorPublicId(publicId) ?? throw new Exception("Usuario não encontrado");
            return Ok(usuario);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var usuarios = await _usuarioServicos.Listar();
            return Ok(usuarios);
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastro(UsuarioCadastroDTO dto)
        {
            // TODO: ADICIONAR ÀS ROTAS CONVENIENTES
            var usuarioId = User.FindFirst("UsuarioId")?.Value;
            var nome = User.FindFirst("Nome")?.Value;
            var perfil = User.FindFirst("Perfil")?.Value;

            await _usuarioServicos.Cadastrar(dto);
            return Ok();
        }

        [HttpPost("cadastroBulk")]
        public async Task<IActionResult> CadastroBulk(List<UsuarioCadastroDTO> dto)
        {
            await _usuarioServicos.CadastrarBulk(dto);
            return Ok();
        }

        [HttpPut("atualizacao")]
        public async Task<IActionResult> Atualizacao(UsuarioAtualizacaoDTO dto)
        {
            await _usuarioServicos.Atualizar(dto);
            return Ok();
        }

        [HttpDelete("deletar")]
        public async Task<IActionResult> Deletar(Guid publicId)
        {
            await _usuarioServicos.Deletar(publicId);
            return Ok();
        }
    }
}
