using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class LojaMap : IEntityTypeConfiguration<Loja>
    {
        public void Configure(EntityTypeBuilder<Loja> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.NomeFantasia).IsRequired();
            builder.Property(l => l.CNPJ).IsRequired();
            builder.HasOne(l => l.Cidade).WithMany(c => c.Lojas).HasForeignKey(l => l.CidadeId).IsRequired();
            builder.HasOne(l => l.Endereco).WithMany(e => e.Lojas).HasForeignKey(l => l.EnderecoId).IsRequired();
        }
    }
}