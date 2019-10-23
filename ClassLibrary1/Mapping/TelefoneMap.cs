using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class TelefoneMap : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.TipoTelefone).WithMany(t => t.Telefones).HasForeignKey(t => t.TipoTelefoneId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Anuncio).WithMany(a => a.Telefones).HasForeignKey(t => t.AnuncioId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Loja).WithMany(l => l.Telefones).HasForeignKey(t => t.LojaId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Evento).WithMany(l => l.Telefones).HasForeignKey(t => t.EventoId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}