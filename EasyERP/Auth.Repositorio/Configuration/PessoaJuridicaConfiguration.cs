using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auth.Repositorio.Entidades;

namespace Auth.Repositorio.Configuration;

public class PessoaJuridicaConfiguration : IEntityTypeConfiguration<PessoaJuridica>
{
    public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
    {
        builder.ToTable("PESSOASJURIDICAS");

        builder.HasIndex(p => p.PublicId).IsUnique();

        builder.HasOne(pj => pj.Responsavel)
               .WithMany()
               .HasForeignKey(pj => pj.ResponsavelId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Endereco)
               .WithMany()
               .HasForeignKey(x => x.EnderecoId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}