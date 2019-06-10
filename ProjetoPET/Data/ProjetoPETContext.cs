using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjetoPET.Models
{
    public class ProjetoPETContext : DbContext
    {
        public ProjetoPETContext (DbContextOptions<ProjetoPETContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoPET.Models.Lojas> Lojas { get; set; }
    }
}
