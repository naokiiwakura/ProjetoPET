using Data.Mapping;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class BancoContext : DbContext
    {
        public DbSet<Anuncio> Anuncios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnuncioMap());
        }
    }
}
