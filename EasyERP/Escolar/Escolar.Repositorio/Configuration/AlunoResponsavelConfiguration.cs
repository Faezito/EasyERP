using Escolar.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escolar.Repositorio.Configuration;

internal class AlunoResponsavelConfiguration : IEntityTypeConfiguration<AlunoResponsavel>
{
    public void Configure(EntityTypeBuilder<AlunoResponsavel> builder)
    {
        builder.ToTable("AlunosResponsaveis", "Escolar");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Aluno)
               .WithMany(x => x.Responsaveis)
               .HasForeignKey(x => x.AlunoId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Responsavel)
               .WithMany()
               .HasForeignKey(x => x.PessoaId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Parentesco)
               .HasMaxLength(50)
               .IsRequired();

        builder.HasIndex(x => new { x.AlunoId, x.PessoaId })
               .IsUnique();

        builder.Property(x => x.CriadoEm)
               .HasColumnType("smalldatetime");

        builder.Property(x => x.AtualizadoEm)
               .HasColumnType("smalldatetime");
    }
}