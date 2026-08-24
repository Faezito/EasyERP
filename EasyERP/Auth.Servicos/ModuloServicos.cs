using Auth.Repositorio;
using Auth.Repositorio.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Auth.Servicos;

public interface IModuloServicos : ICRUDGenerico<Modulo>
{
    Task AtribuirModulo(UsuarioModulo usuarioModulo);
    Task Cadastrar(Modulo modulo);
    new Task Atualizar(Modulo modulo);
    Task Deletar(int id);
}

public class ModuloServicos : CRUDGenerico<Modulo>, IModuloServicos
{
    private readonly IMapper _mapper;

    public ModuloServicos(AppDbContext db, IMapper mapper) : base(db)
    {
        _mapper = mapper;
    }

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

    public async Task AtribuirModulo(UsuarioModulo usuarioModulo)
    {
        _db.Set<UsuarioModulo>().Add(usuarioModulo);
        await SalvarAsync();
    }
}
