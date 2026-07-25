using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuarios.Model.Entidades;

namespace Usuarios.Repositorio.Configuration;

public class PessoaConfiguration : IEntityTypeConfiguration<PessoaFisica>
{
    public void Configure(EntityTypeBuilder<PessoaFisica> builder)
    {
        builder.ToTable("PESSOAS");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.NomeCompleto)
               .HasMaxLength(400)
               .IsRequired();

        builder.Property(x => x.Email)
               .HasMaxLength(255)
               .IsRequired();

        builder.Property(x => x.Telefone)
               .HasMaxLength(20)
               .IsRequired();

        builder.HasIndex(x => x.Telefone)
               .IsUnique();

        builder.HasIndex(x => x.Email)
               .IsUnique();

        builder.Property(x => x.NomeUsuario)
               .HasMaxLength(60)
               .IsRequired();

        builder.HasIndex(x => x.NomeUsuario)
               .IsUnique();

        builder.HasIndex(x => x.CPF)
               .IsUnique();

        builder.Property(x => x.CriadoEm)
               .HasColumnType("smalldatetime");

        builder.Property(x => x.DataNascimento)
               .HasColumnType("smalldatetime");

        builder.Property(x => x.AtualizadoEm)
               .HasColumnType("smalldatetime");

        builder.HasOne(x => x.Endereco)
               .WithMany()
               .HasForeignKey(x => x.EnderecoId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}