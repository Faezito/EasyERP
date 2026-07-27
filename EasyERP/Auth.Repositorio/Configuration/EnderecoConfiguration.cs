using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auth.Repositorio.Entidades;

namespace Auth.Repositorio.Configuration;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("ENDERECOS");

        builder.HasKey(x => x.Id);

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
    }
}