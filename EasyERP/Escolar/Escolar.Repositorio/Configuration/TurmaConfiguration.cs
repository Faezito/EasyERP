using Escolar.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escolar.Repositorio.Configuration;

internal class TurmaConfiguration : IEntityTypeConfiguration<Turma>
{
    public void Configure(EntityTypeBuilder<Turma> builder)
    {
        builder.ToTable("Turmas", "Escolar");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Descricao)
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(x => x.Sala)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.Predio)
               .HasMaxLength(100);

        builder.HasMany(x => x.Alunos)
               .WithOne(x => x.Turma)
               .HasForeignKey(x => x.TurmaId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Responsavel)
               .WithMany()
               .HasForeignKey(x => x.ResponsavelId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ViceResponsavel)
               .WithMany()
               .HasForeignKey(x => x.ViceResponsavelId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.CriadoEm)
               .HasColumnType("smalldatetime");

        builder.Property(x => x.AtualizadoEm)
               .HasColumnType("smalldatetime");
    }
}