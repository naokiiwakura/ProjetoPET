using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Nome).IsRequired();
            builder.HasOne(e => e.Cidade).WithMany(c => c.Eventos).HasForeignKey(e => e.CidadeId).IsRequired();
            builder.HasOne(e => e.Endereco).WithMany(e => e.Eventos).HasForeignKey(e => e.EnderecoId).IsRequired();
            builder.HasMany(e => e.Telefones).WithOne(t => t.Evento);
        }
    }
}