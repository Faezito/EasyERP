using Admin.Repositorio;
using Admin.Repositorio.Entidades;

namespace Admin.Servicos;

public interface IApiExternaServicos : ICRUDGenerico<ApiExterna>
{
    Task AtualizarAsync(ApiExterna api);
}

public class ApiExternaServicos(AppDbContext db) : CRUDGenerico<ApiExterna>(db), IApiExternaServicos
{
    public async Task AtualizarAsync(ApiExterna api)
    {
        _dbSet.Update(api);
        await _db.SaveChangesAsync();
    }
}
