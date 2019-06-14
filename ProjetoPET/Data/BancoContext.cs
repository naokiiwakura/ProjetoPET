using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    public DbSet<Usuario> Usuario { get; set; }

    public DbSet<TipoUsuario> UsuarioBusiness { get; set; }

    public DbSet<Pet> Pet { get; set; }

    public DbSet<Adocao> Adocao { get; set; }

    public DbSet<Eventos> Eventos { get; set; }

    public DbSet<Lojas> Lojas { get; set; }

    public DbSet<IdentityUserClaim<string>> IdentityUserClaims { get; set; }

    public DbSet<IdentityUserLogin<string>> IdentityUserLogins { get; set; }

    public DbSet<IdentityUserToken<string>> IdentityUserTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(u => u.UserId);
        modelBuilder.Entity<IdentityUserToken<string>>().HasKey(u => u.UserId);
    }
}

