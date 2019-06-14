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

    public DbSet<Produto> Produtos { get; set; }

    public DbSet<IdentityUserClaim<string>> IdentityUserClaims { get; set; }
}

