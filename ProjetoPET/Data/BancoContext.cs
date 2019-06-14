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

        public DbSet<ProjetoPET.Models.TipoUsuario> UsuarioBusiness { get; set; }

        public DbSet<ProjetoPET.Models.Pet> Pet { get; set; }

        public DbSet<ProjetoPET.Models.Adocao> Adocao { get; set; }

        public DbSet<Eventos> Eventos { get; set; }

        public DbSet<IdentityUserClaim<string>> IdentityUserClaims { get; set; }
}

