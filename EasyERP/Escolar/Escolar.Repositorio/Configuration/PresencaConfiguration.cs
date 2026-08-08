using Escolar.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escolar.Repositorio.Configuration;

public class PresencaConfiguration : IEntityTypeConfiguration<Presenca>
{
    public void Configure(EntityTypeBuilder<Presenca> builder)
    {
        builder.ToTable("Presencas", "Escolar");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Aluno)
               .WithMany(x => x.Presencas)
               .HasForeignKey(x => x.AlunoId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Professor)
               .WithMany()
               .HasForeignKey(x => x.ProfessorId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Turma)
               .WithMany()
               .HasForeignKey(x => x.TurmaId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Disciplina)
               .WithMany(x => x.Presencas)
               .HasForeignKey(x => x.DisciplinaId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Data)
               .HasColumnType("smalldatetime");

        builder.Property(x => x.CriadoEm)
               .HasColumnType("smalldatetime");

        builder.Property(x => x.AtualizadoEm)
               .HasColumnType("smalldatetime");
    }
}