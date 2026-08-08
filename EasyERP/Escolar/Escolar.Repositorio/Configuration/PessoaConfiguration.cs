using Escolar.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Repositorio.Configuration;

public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("Pessoas", "Escolar");

        builder.HasIndex(p => p.PublicId).IsUnique();

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

        builder.HasIndex(x => x.CPF)
               .IsUnique();

        builder.Property(x => x.CriadoEm)
               .HasColumnType("smalldatetime");

        builder.Property(x => x.DataNascimento)
               .HasColumnType("smalldatetime");

        builder.Property(x => x.AtualizadoEm)
               .HasColumnType("smalldatetime");
    }
}