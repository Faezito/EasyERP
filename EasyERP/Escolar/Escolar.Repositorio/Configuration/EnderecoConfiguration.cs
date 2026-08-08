using Escolar.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escolar.Repositorio.Configuration;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("Enderecos", "Escolar");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.PessoaId);

        builder.Property(x => x.CEP)
               .HasMaxLength(8)
               .IsRequired();

        builder.Property(x => x.Logradouro)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(x => x.Numero)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(x => x.Complemento)
               .HasMaxLength(100);

        builder.Property(x => x.Bairro)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(x => x.Cidade)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(x => x.Estado)
               .HasMaxLength(2)
               .IsRequired();

        builder.Property(x => x.Pais)
               .HasMaxLength(100)
               .IsRequired();

        builder.HasOne(x => x.Pessoa)
               .WithMany()
               .HasForeignKey(x => x.PessoaId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}