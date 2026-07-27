using Auth.Repositorio.Entidades;
using AutoMapper;
using CrossCutting.Model.DTOs.Acesso;
using CrossCutting.Model.DTOs.Login;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.DTOs.Usuario;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using bC = BCrypt.Net.BCrypt;

namespace Auth.Servicos
{
    public interface IAcessoServicos
    {
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task Logout();
    }

    public class AcessoServicos(IUsuarioServicos usuarioServicos, IConfiguration config, IMapper mapper) : IAcessoServicos
    {
        private readonly IUsuarioServicos _usuarioServicos = usuarioServicos;
        private readonly IConfiguration _config = config;
        private readonly IMapper _mapper = mapper;

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var usuario = await _usuarioServicos.ObterPorLogin(loginRequestDTO.Login)
                ?? throw new Exception("Credenciais inválidas.");

            if (!bC.Verify(loginRequestDTO.Senha, usuario.SenhaHash)) throw new Exception("Credenciais inválidas.");

            var usuarioRes = _mapper.Map<UsuarioRespostaDTO>(usuario);
            var claims = CriarClaims(usuario);

            return new LoginResponseDTO
            {
                Token = GerarToken(claims),
                Expiracao = DateTime.Now.AddHours(8),
                Usuario = usuarioRes
            };
        }

        private string GerarToken(IEnumerable<Claim> claims)
        {
            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

            var credenciais = new SigningCredentials(
                chave,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: credenciais
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private IEnumerable<Claim> CriarClaims(Usuario usuario)
        {
            return new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, usuario.PublicId.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, usuario.NomeUsuario),
                new(JwtRegisteredClaimNames.Name, usuario.PessoaFisica.NomeCompleto),
                new(JwtRegisteredClaimNames.Email, usuario.PessoaFisica.Email),

                new(ClaimTypes.NameIdentifier, usuario.PublicId.ToString()),
                new(ClaimTypes.Name, usuario.NomeUsuario),
                new(ClaimTypes.Role, usuario.Perfil.ToString()),

                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
        }
    }
}
