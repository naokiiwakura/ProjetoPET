using Data.Mapping;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<TipoAnuncio> TipoAnuncios { get; set; }
        public DbSet<TipoTelefone> TipoTelefones { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public int MyProperty { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnuncioMap());
            modelBuilder.ApplyConfiguration(new CidadeMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new EventoMap());
            modelBuilder.ApplyConfiguration(new LojaMap());
            modelBuilder.ApplyConfiguration(new PetMap());
            modelBuilder.ApplyConfiguration(new TelefoneMap());
            modelBuilder.ApplyConfiguration(new TipoAnuncioMap());
            modelBuilder.ApplyConfiguration(new TipoTelefoneMap());
            modelBuilder.ApplyConfiguration(new TipoUsuarioMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}