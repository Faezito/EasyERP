using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuarios.Repositorio.Entidades;

namespace Usuarios.Repositorio.Configuration
{
    public class UsuarioModuloConfiguration : IEntityTypeConfiguration<UsuarioModulo>
    {
        public void Configure(EntityTypeBuilder<UsuarioModulo> builder)
        {
            builder.HasOne(um => um.Usuario)
                .WithMany(u => u.Acessos)
                .HasForeignKey(um => um.UsuarioId);

            builder.HasOne(um => um.EmpresaModulo)
                .WithMany(em => em.Acessos)
                .HasForeignKey(um => um.EmpresaModuloId);

            builder.HasIndex(um => new { um.UsuarioId, um.EmpresaModuloId }).IsUnique();
        }
    }
}
