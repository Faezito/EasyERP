using CrossCutting.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuarios.Repositorio.Entidades;

namespace Usuarios.Repositorio.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIOS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeUsuario)
                   .HasMaxLength(60)
                   .IsRequired();

            builder.Property(x => x.SenhaHash)
                   .HasMaxLength(60)
                   .IsRequired();

            builder.Property(x => x.Perfil)
                   .HasDefaultValue(Perfil.Pessoa);

            builder.HasOne(x => x.PessoaFisica)
                   .WithOne()
                   .HasForeignKey<Usuario>(x => x.PessoaFisicaId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
        }
    }
}
