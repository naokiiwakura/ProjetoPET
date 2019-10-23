using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class PetMap : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Sexo).IsRequired().HasMaxLength(1);
        }
    }
}