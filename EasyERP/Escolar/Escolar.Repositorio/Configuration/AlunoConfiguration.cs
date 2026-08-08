using Escolar.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escolar.Repositorio.Configuration;

public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.ToTable("Alunos", "Escolar");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Turma)
               .WithMany(x => x.Alunos)
               .HasForeignKey(x => x.TurmaId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Pessoa)
               .WithOne()
               .HasForeignKey<Aluno>(x => x.PessoaId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}