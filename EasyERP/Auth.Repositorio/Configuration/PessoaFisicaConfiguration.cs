using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auth.Repositorio.Entidades;

namespace Auth.Repositorio.Configuration;

public class PessoaFisicaConfiguration : IEntityTypeConfiguration<PessoaFisica>
{
    public void Configure(EntityTypeBuilder<PessoaFisica> builder)
    {
        builder.ToTable("PESSOAS");

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

        builder.HasOne(pf => pf.Empresa)
               .WithMany()
               .HasForeignKey(pf => pf.EmpresaId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Endereco)
               .WithMany()
               .HasForeignKey(x => x.EnderecoId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}