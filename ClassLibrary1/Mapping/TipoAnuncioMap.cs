using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class TipoAnuncioMap : IEntityTypeConfiguration<TipoAnuncio>
    {
        public void Configure(EntityTypeBuilder<TipoAnuncio> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}