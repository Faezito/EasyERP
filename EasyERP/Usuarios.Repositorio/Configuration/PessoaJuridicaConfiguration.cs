using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuarios.Repositorio.Entidades;

namespace Usuarios.Repositorio.Configuration;

public class PessoaJuridicaConfiguration : IEntityTypeConfiguration<PessoaJuridica>
{
    public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
    {
        builder.ToTable("PESSOASJURIDICAS");

        //builder.HasKey(x => x.Id);

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