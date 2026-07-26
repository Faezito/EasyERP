using CrossCutting.Auditoria;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Usuarios.Repositorio.Entidades;

namespace Usuarios.Repositorio;

public partial class AppDbContext : DbContextAuditavel
{
    public AppDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) 
        : base(options, httpContextAccessor)
    {
    }

    public DbSet<PessoaFisica> PessoasFisicas { get; set; }
    public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PessoaBase>().UseTpcMappingStrategy();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
