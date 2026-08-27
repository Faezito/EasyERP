using Auth.Repositorio;
using Auth.Repositorio.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.DTOs;

namespace Auth.Servicos;

public interface IModuloServicos : ICRUDGenerico<Modulo>
{
    Task<List<ModuloDTO>> ListarTodos();
    Task AtribuirModulo(UsuarioModuloDTO dto);
    Task Cadastrar(Modulo modulo);
    new Task Atualizar(Modulo modulo);
    Task Deletar(int id);
}

public class ModuloServicos(AppDbContext db, IMapper mapper, IUsuarioServicos usuarioServicos) : CRUDGenerico<Modulo>(db), IModuloServicos
{
    private readonly IMapper _mapper = mapper;
    private readonly IUsuarioServicos _usuarioServicos = usuarioServicos;

    public async Task Cadastrar(Modulo modulo)
    {
        Adicionar(modulo);
        await SalvarAsync();
    }

    public new async Task Atualizar(Modulo modulo)
    {
        var existente = await _dbSet.FirstOrDefaultAsync(x => x.Id == modulo.Id);
        if (existente == null)
            throw new Exception("Módulo não encontrado.");

        existente.Nome = modulo.Nome;
        existente.Descricao = modulo.Descricao;
        existente.Ativo = modulo.Ativo;
        existente.BaseUrl = modulo.BaseUrl;
        existente.HealthCheckPath = modulo.HealthCheckPath;
        existente.VersaoApi = modulo.VersaoApi;

        await SalvarAsync();
    }

    public async Task Deletar(int id)
    {
        var modulo = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (modulo == null)
            throw new Exception("Módulo não encontrado.");

        _dbSet.Remove(modulo);
        await SalvarAsync();
    }

    public async Task AtribuirModulo(UsuarioModuloDTO dto)
    {
        var usuario = await _db.Usuarios.FirstOrDefaultAsync(x=>x.PublicId == dto.UsuarioId)
            ?? throw new Exception("Usuario não encontrado");

        var usuarioModulo = new UsuarioModulo{
            UsuarioId = usuario.Id,
            ModuloId = dto.ModuloId,
        };

        _db.Set<UsuarioModulo>().Add(usuarioModulo);
        await SalvarAsync();
    }

    public async Task<List<ModuloDTO>> ListarTodos()
    {
        var modulos = await _dbSet.ToListAsync();
        return _mapper.Map<List<ModuloDTO>>(modulos);
    }
}
