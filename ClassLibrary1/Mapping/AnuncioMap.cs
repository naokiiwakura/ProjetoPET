using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Mapping
{

    public class AnuncioMap : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Titulo).IsRequired();
            builder.HasOne(a => a.Pet).WithMany(p => p.Anuncios).HasForeignKey(a => a.PetId).IsRequired();
            builder.HasOne(a => a.TipoAnuncio).WithMany(t => t.Anuncios).HasForeignKey(a => a.TipoAnuncioId).IsRequired();
            builder.HasOne(a => a.Endereco).WithMany(e => e.Anuncios).HasForeignKey(a => a.EnderecoId);
            builder.HasOne(a => a.Cidade).WithMany(c => c.Anuncios).HasForeignKey(a => a.CidadeId);
        }
    }
}