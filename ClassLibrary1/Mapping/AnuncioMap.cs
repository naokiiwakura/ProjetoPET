using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Mapping
{

    public class AnuncioMap : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(t => t.Titulo)
                    .IsRequired();

            builder.HasOne(p => p.Pet).WithMany(p => p.Anuncios).HasForeignKey(p => p.PetId);

            builder.HasOne(p => p.Anunciante).WithMany(p => p.Anuncios).HasForeignKey(p => p.AnuncianteId);

            builder.HasOne(p => p.TipoAnuncio).WithMany(p => p.Anuncios).HasForeignKey(p => p.TipoAnuncioId);

            builder.HasOne(p => p.Endereco).WithMany(p => p.Anuncios).HasForeignKey(p => p.EnderecoId);

            builder.HasMany(p => p.Telefones).


        }
    }
}
