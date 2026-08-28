using Auth.Repositorio;
using Auth.Repositorio.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.DTOs;

namespace Auth.Servicos;

public interface IUsuarioModuloServicos : ICRUDGenerico<UsuarioModulo>
{
    Task AtribuirModulo(UsuarioModuloDTO dto);
    Task<List<UsuarioModuloDTO>> ListarModulosDoUsuario(Guid usuarioId);
    Task RemoverAcesso(Guid usuarioId, int moduloId);
}

public class UsuarioModuloServicos(AppDbContext db, IMapper mapper) : CRUDGenerico<UsuarioModulo>(db), IUsuarioModuloServicos
{
    private readonly IMapper _mapper = mapper;

    public async Task AtribuirModulo(UsuarioModuloDTO dto)
    {
        var usuario = await _db.Usuarios.FirstOrDefaultAsync(x => x.PublicId == dto.UsuarioId)
            ?? throw new Exception("Usuario não encontrado");

        var usuarioModulo = new UsuarioModulo
        {
            UsuarioId = usuario.Id,
            ModuloId = dto.ModuloId,
        };

        _db.Set<UsuarioModulo>().Add(usuarioModulo);
        await SalvarAsync();
    }

    public async Task<List<UsuarioModuloDTO>> ListarModulosDoUsuario(Guid usuarioId)
    {
        var usuario = await _db.Usuarios.FirstOrDefaultAsync(x => x.PublicId == usuarioId)
            ?? throw new Exception("Usuário não encontrado");

        var usuarioModulos = await _db.Set<UsuarioModulo>()
                                      .Include(x => x.Modulo)
                                      .Where(x => x.UsuarioId == usuario.Id)
                                      .ToListAsync();

        return _mapper.Map<List<UsuarioModuloDTO>>(usuarioModulos);
    }

    public async Task RemoverAcesso(Guid usuarioId, int moduloId)
    {
        var usuario = await _db.Usuarios.FirstOrDefaultAsync(x => x.PublicId == usuarioId)
            ?? throw new Exception("Usuário não encontrado");

        var usuarioModulo = await _db.Set<UsuarioModulo>()
                                      .Include(x => x.Modulo)
                                      .FirstOrDefaultAsync(x => x.UsuarioId == usuario.Id && x.ModuloId == moduloId);

        _db.Set<UsuarioModulo>().Remove(usuarioModulo);
        await SalvarAsync();
    }
}
