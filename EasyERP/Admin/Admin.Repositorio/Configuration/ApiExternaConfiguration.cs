using Admin.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Repositorio.Configuration;

public class ApiExternaConfiguration : IEntityTypeConfiguration<ApiExterna>
{
    public void Configure(EntityTypeBuilder<ApiExterna> builder)
    {
        builder.ToTable("ApisExternas");
        builder.HasKey(x => x.Id);
    }
}