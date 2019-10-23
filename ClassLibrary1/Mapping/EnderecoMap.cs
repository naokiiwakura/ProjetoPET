using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Cep).IsRequired();
            builder.Property(e => e.Rua).IsRequired();
        }
    }
}