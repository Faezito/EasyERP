using Auth.Repositorio;
using Auth.Repositorio.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.DTOs.Usuario;
using bC = BCrypt.Net.BCrypt;

namespace Auth.Servicos;

public interface IUsuarioServicos : ICRUDGenerico<Usuario>
{
    Task Cadastrar(UsuarioCadastroDTO dto);
    Task CadastrarBulk(List<UsuarioCadastroDTO> dto);
    Task Atualizar(UsuarioAtualizacaoDTO dto);
    Task<UsuarioRespostaDTO> ObterPorId(int id);
    Task<UsuarioRespostaDTO> ObterPorPublicId(Guid publicId);
    Task<Usuario?> ObterPorLogin(string login);
    Task<List<UsuarioRespostaDTO>> Listar();
    Task Deletar(Guid publicId);
}

public class UsuarioServicos : CRUDGenerico<Usuario>, IUsuarioServicos
{
    private readonly IMapper _mapper;
    public UsuarioServicos(AppDbContext db, IMapper mapper) : base(db)
    {
        _mapper = mapper;
    }

    public async Task Atualizar(UsuarioAtualizacaoDTO dto)
    {
        var usuario = await _db.Usuarios.FirstOrDefaultAsync(x => x.PublicId == dto.PublicId)
            ?? throw new Exception("Erro ao atualizar: usuário não encontrado.");

        usuario.SenhaHash = string.IsNullOrWhiteSpace(dto.Senha) ? usuario.SenhaHash : bC.HashPassword(dto.Senha);
        usuario.Perfil = dto.Perfil ?? usuario.Perfil;

        await SalvarAsync();
    }

    public async Task Cadastrar(UsuarioCadastroDTO dto)
    {
        var usuario = _mapper.Map<Usuario>(dto);
        var pessoa = _mapper.Map<PessoaFisica>(dto);

        usuario.SenhaHash = bC.HashPassword(dto.Senha);
        usuario.PessoaFisica = pessoa;

        Adicionar(usuario);
        await SalvarAsync();
    }

    public async Task CadastrarBulk(List<UsuarioCadastroDTO> dto)
    {
        foreach (var item in dto)
        {
            var usuario = _mapper.Map<Usuario>(item);
            var pessoa = _mapper.Map<PessoaFisica>(item);

            usuario.SenhaHash = bC.HashPassword(item.Senha);
            usuario.PessoaFisica = pessoa;

            Adicionar(usuario);
        }
        await SalvarAsync();
    }

    public async Task Deletar(Guid publicId)
    {
        var usuario = await _db.Usuarios.FirstOrDefaultAsync(x => x.PublicId == publicId);
        if (usuario == null) throw new Exception("Erro ao excluir: Usuario não encontrado.");

        usuario.Deletar();
        await SalvarAsync();
    }

    public async Task<List<UsuarioRespostaDTO>> Listar()
    {
        var usuarios = await _dbSet
            .Include(x => x.PessoaFisica)
            .ThenInclude(x => x.Endereco)
            .ToListAsync();
        return _mapper.Map<List<UsuarioRespostaDTO>>(usuarios);
    }

    public async Task<UsuarioRespostaDTO> ObterPorId(int id)
    {
        var usuario = await _db.Usuarios
            .Include(x => x.Modulos)
                .ThenInclude(x => x.Modulo)
            .FirstOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<UsuarioRespostaDTO>(usuario);
    }

    public async Task<Usuario?> ObterPorLogin(string login)
    {
        return await _dbSet
            .Include(x => x.PessoaFisica)
            .FirstOrDefaultAsync(x => x.NomeUsuario == login || x.PessoaFisica.Email == login);
    }

    public async Task<UsuarioRespostaDTO> ObterPorPublicId(Guid publicId)
    {
        var usuario = await _db.Usuarios
            .Include(x => x.Modulos)
            //.ThenInclude(x => x.Modulo)
            .FirstOrDefaultAsync(x => x.PublicId == publicId);
        return _mapper.Map<UsuarioRespostaDTO>(usuario);
    }
}
