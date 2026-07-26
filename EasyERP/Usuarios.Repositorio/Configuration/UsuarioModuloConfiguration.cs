using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuarios.Model.Entidades;

namespace Usuarios.Repositorio.Configuration
{
    public class UsuarioModuloConfiguration : IEntityTypeConfiguration<UsuarioModulo>
    {
        public void Configure(EntityTypeBuilder<UsuarioModulo> builder)
        {
            builder.HasOne(um => um.Usuario)
                .WithMany()
                .HasForeignKey(um => um.UsuarioId);

            builder.HasOne(um => um.EmpresaModulo)
                .WithMany()
                .HasForeignKey(um => um.EmpresaModuloId);

            builder.HasIndex(um => new { um.UsuarioId, um.EmpresaModuloId }).IsUnique();
        }
    }
}
