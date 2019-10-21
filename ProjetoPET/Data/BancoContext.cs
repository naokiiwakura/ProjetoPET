using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetoPET.Areas.Identity.Data;
using ProjetoPET.Models;

public class BancoContext : DbContext
{
    public BancoContext(DbContextOptions<BancoContext> options)
        : base(options)
    {
    }

    public BancoContext()
    {
    }

    public DbSet<Usuario> Usuario { get; set; }

    public DbSet<TipoUsuario> UsuarioBusiness { get; set; }

    public DbSet<Pet> Pet { get; set; }

    public DbSet<Anuncio> Anuncio { get; set; }

    public DbSet<Eventos> Eventos { get; set; }

    public DbSet<Loja> Lojas { get; set; }

    public DbSet<IdentityUserClaim<string>> IdentityUserClaims { get; set; }

    public DbSet<IdentityUserLogin<string>> IdentityUserLogins { get; set; }

    public DbSet<IdentityUserToken<string>> IdentityUserTokens { get; set; }

    public DbSet<Cidade> Cidade { get; set; }

    public DbSet<Estado> Estado { get; set; }

    public DbSet<TipoAnuncio> TipoAnuncio { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(u => u.UserId);
        modelBuilder.Entity<IdentityUserToken<string>>().HasKey(u => u.UserId);
    }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries()
            .Where(entry => entry.Entity.GetType().GetProperty("CreatedDate") != null))
        {
            if (entry.State == EntityState.Added)
                entry.Property("CreatedDate").CurrentValue = DateTime.Now;

            if (entry.State == EntityState.Modified)
                entry.Property("CreatedDate").IsModified = false;
        }
        return base.SaveChanges();  
    }
}

