using Auth.Repositorio;
using Auth.Repositorio.Entidades;
using AutoMapper;
using CrossCutting.Model.DTOs.Login;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.DTOs.PessoaFisica;
using Model.DTOs.Usuario;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using bC = BCrypt.Net.BCrypt;

namespace Auth.Servicos;

public interface IAcessoServicos
{
    Task<LoginResponseDTO> Login(LoginRequestDTO dto);
}

public class AcessoServicos(AppDbContext db, IMapper mapper, IConfiguration configuration) : IAcessoServicos
{
    private readonly AppDbContext _db = db;
    private readonly IMapper _mapper = mapper;
    private readonly IConfiguration _configuration = configuration;

    public async Task<LoginResponseDTO> Login(LoginRequestDTO dto)
    {
        var usuario = await _db.Set<Usuario>()
                               .Include(x => x.PessoaFisica)
                               .Include(x => x.Modulos)
                                   .ThenInclude(x => x.Modulo)
                               .SingleOrDefaultAsync(x => x.NomeUsuario == dto.Login || x.PessoaFisica.Email == dto.Login);

        if (usuario == null || !bC.Verify(dto.Senha, usuario.SenhaHash))
            throw new Exception("Credenciais inválidas");

        var usuarioRes = _mapper.Map<UsuarioRespostaDTO>(usuario);
        var claims = CriarClaims(usuario);
        usuarioRes.Pessoa = _mapper.Map<PessoaFisicaRespostaDTO>(usuario.PessoaFisica);

        var resposta = new LoginResponseDTO
        {
            Usuario = usuarioRes,
            Token = GerarToken(claims)
        };

        return resposta;
    }



    private string GerarToken(IEnumerable<Claim> claims)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

        var credentials = new SigningCredentials(
            key,
                SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
        issuer: _configuration["Jwt:Issuer"],
        audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
        signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private IEnumerable<Claim> CriarClaims(Usuario usuario)
    {
        return new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, usuario.NomeUsuario),
                new(JwtRegisteredClaimNames.Name, usuario.PessoaFisica.NomeCompleto),
                new(JwtRegisteredClaimNames.Email, usuario.PessoaFisica.Email),

                new (ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new (ClaimTypes.Name, usuario.NomeUsuario),
                new (ClaimTypes.Role, usuario.Perfil.ToString()),

                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
    }
}