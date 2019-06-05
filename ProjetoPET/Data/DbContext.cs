using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoPET.Models;

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext (DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoPET.Models.Usuario> Usuario { get; set; }

        public DbSet<ProjetoPET.Models.UsuarioBusiness> UsuarioBusiness { get; set; }

        public DbSet<ProjetoPET.Models.Pet> Pet { get; set; }

        public DbSet<ProjetoPET.Models.Adocao> Adocao { get; set; }

        public DbSet<ProjetoPET.Models.Eventos> Eventos { get; set; }
    }
