using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoPET.Models;

    public class ProjetoPETContext : DbContext
    {
        public ProjetoPETContext (DbContextOptions<ProjetoPETContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoPET.Models.TelaDeAdocao> TelaDeAdocao { get; set; }
    }
