using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Escolar.Repositorio;

public interface ICRUDGenerico<T> where T : class
{
    Task<T?> ObterPorIdAsync(int id);
    Task<T?> ObterPorIdAsync(Guid publicId);
    Task<List<T>> ObterTodosAsync();
    Task AdicionarAsync(T entity);
    void Atualizar(T entity);
    Task AtualizarAsync(T entity);
    void Adicionar(T entity);
    void Remover(T entity);
    void BulkRemove(List<T> entities);
    Task RemoverAsync(T entity);
    Task SalvarAsync();
}

public class CRUDGenerico<T> : ICRUDGenerico<T> where T : class
{
    protected readonly AppDbContext _db;
    protected readonly DbSet<T> _dbSet;
    protected readonly IMapper _mapper;

    public CRUDGenerico(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _dbSet = db.Set<T>();
        _mapper = mapper;
    }

    public async Task<T?> ObterPorIdAsync(int id)
        => await _dbSet.FindAsync(id);

    public async Task<List<T>> ObterTodosAsync()
        => await _dbSet.ToListAsync();

    public async Task AdicionarAsync(T entity)
    {
        _dbSet.Add(entity);
        await _db.SaveChangesAsync();
    }

    public void Adicionar(T entity)
        => _dbSet.Add(entity);

    public void Atualizar(T entity)
        => _dbSet.Update(entity);

    public async Task AtualizarAsync(T entity)
    {
        _dbSet.Update(entity);
        await _db.SaveChangesAsync();
    }

    public void Remover(T entity)
        => _dbSet.Remove(entity);

    public async Task SalvarAsync()
        => await _db.SaveChangesAsync();

    public void BulkRemove(List<T> entities)
    {
        foreach (var entity in entities)
            _dbSet.Remove(entity);
    }

    public async Task RemoverAsync(T entity)
    {
        _dbSet.Remove(entity);
        await SalvarAsync();
    }

    public async Task<T?> ObterPorIdAsync(Guid publicId) => await _dbSet.FindAsync(publicId);
}
