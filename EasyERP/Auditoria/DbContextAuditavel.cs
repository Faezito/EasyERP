using CrossCutting.Auditoria;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public abstract class DbContextAuditavel : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    protected DbContextAuditavel(DbContextOptions options, IHttpContextAccessor httpContextAccessor) 
        : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override int SaveChanges()
    {
        AplicarAuditoria();
        return base.SaveChanges();
    }

    private void AplicarAuditoria()
    {
        var usuarioId = ObterUsuarioAtual();
        var entradas = ChangeTracker.Entries<EntidadeAuditavel>();

        foreach (var entrada in entradas)
        {
            if (entrada.State == EntityState.Added)
            {
                entrada.Entity.CriadoEm = DateTime.UtcNow;
                entrada.Entity.CriadoPor = usuarioId;
            }

            if (entrada.State == EntityState.Modified)
            {
                entrada.Entity.AtualizadoEm = DateTime.UtcNow;
                entrada.Entity.AtualizadoPor = usuarioId;
            }
        }
    }

    private Guid? ObterUsuarioAtual()
    {
        var claim = _httpContextAccessor.HttpContext?.User
            .FindFirst(ClaimTypes.NameIdentifier)?.Value; // ou o claim que você usa pro UserId no JWT

        return Guid.TryParse(claim, out var id) ? id : null;
    }
}