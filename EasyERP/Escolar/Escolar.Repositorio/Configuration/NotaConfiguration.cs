using Escolar.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escolar.Repositorio.Configuration;

public class NotaConfiguration : IEntityTypeConfiguration<Nota>
{
    public void Configure(EntityTypeBuilder<Nota> builder)
    {
        builder.ToTable("Notas", "Escolar");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Aluno)
               .WithMany(x => x.Notas)
               .HasForeignKey(x => x.AlunoId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Professor)
               .WithMany()
               .HasForeignKey(x => x.ProfessorId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Disciplina)
               .WithMany(x => x.Notas)
               .HasForeignKey(x => x.DisciplinaId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Turma)
               .WithMany()
               .HasForeignKey(x => x.TurmaId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.PontosFeitos)
               .HasColumnType("decimal(5,2)");

        builder.Property(x => x.TotalPontos)
               .HasColumnType("decimal(5,2)");

        builder.Property(x => x.DataLancamento)
               .HasColumnType("smalldatetime");

        builder.Property(x => x.CriadoEm)
               .HasColumnType("smalldatetime");

        builder.Property(x => x.AtualizadoEm)
               .HasColumnType("smalldatetime");
    }
}