using Escolar.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escolar.Repositorio.Configuration;

public class DisciplinaConfiguration : IEntityTypeConfiguration<Disciplina>
{
    public void Configure(EntityTypeBuilder<Disciplina> builder)
    {
        builder.ToTable("Disciplinas", "Escolar");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(x => x.Descricao)
               .HasMaxLength(500);

        builder.HasIndex(x => x.Nome)
               .IsUnique();

        builder.Property(x => x.CriadoEm)
               .HasColumnType("smalldatetime");

        builder.Property(x => x.AtualizadoEm)
               .HasColumnType("smalldatetime");
    }
}