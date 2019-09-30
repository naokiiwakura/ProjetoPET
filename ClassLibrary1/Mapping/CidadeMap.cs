using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Estado).WithMany(p => p.Cidades).HasForeignKey(p => p.EstadoId);
        }
    }
}
