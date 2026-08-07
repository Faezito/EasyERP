using Admin.Repositorio.Entidades;
using CrossCutting.Auditoria;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Admin.Repositorio;

public partial class AppDbContext : DbContextAuditavel
{
    public AppDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor)
        : base(options, httpContextAccessor)
    {
    }

    public DbSet<ApiExterna> ApiExterna { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}