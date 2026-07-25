using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Usuarios.Model.Entidades;

namespace Usuarios.Repositorio;

public partial class AppDbContext : DbContextAuditavel
{
    public AppDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) 
        : base(options, httpContextAccessor)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PessoaBase>().UseTpcMappingStrategy();
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
