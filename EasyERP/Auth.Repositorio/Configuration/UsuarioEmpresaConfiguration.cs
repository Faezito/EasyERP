using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auth.Repositorio.Entidades;

namespace Auth.Repositorio.Configuration
{
    public class UsuarioEmpresaConfiguration : IEntityTypeConfiguration<UsuarioEmpresa>
    {
        public void Configure(EntityTypeBuilder<UsuarioEmpresa> builder)
        {
            builder.HasOne(ue => ue.Usuario)
                .WithMany()
                .HasForeignKey(ue => ue.UsuarioId);

            builder.HasOne(ue => ue.PessoaJuridica)
                .WithMany()
                .HasForeignKey(ue => ue.PessoaJuridicaId);

            builder.HasIndex(ue => new { ue.UsuarioId, ue.PessoaJuridicaId }).IsUnique();
        }
    }
}