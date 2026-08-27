using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auth.Repositorio.Entidades;

namespace Auth.Repositorio.Configuration;

public class UsuarioModuloConfiguration : IEntityTypeConfiguration<UsuarioModulo>
{
    public void Configure(EntityTypeBuilder<UsuarioModulo> builder)
    {
        builder.HasOne(um => um.Usuario)
            .WithMany(u => u.Modulos)
            .HasForeignKey(um => um.UsuarioId);

        builder.HasOne(um => um.Modulo)
            .WithMany(m => m.Usuarios)
            .HasForeignKey(um => um.ModuloId);

        builder.HasIndex(um => new { um.UsuarioId, um.ModuloId })
            .IsUnique();
    }
}