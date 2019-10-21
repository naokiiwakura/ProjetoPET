using Microsoft.AspNetCore.Http;
using ProjetoPET.Models;
using ProjetoPET.Repository.Interfaces;
using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace ProjetoPET.Repository
{
    public class LojaRepository : RepositoryBase<Loja>, ILojaRepository
    {
        public LojaRepository(BancoContext db) : base(db) { }

        string uniqueFileName = null;


        public string ConverterFoto(IFormFile e, string hosting)
        {
            string uploadsFolder = Path.Combine(hosting, "images/LojasPhotos");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + e.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            e.CopyTo(new FileStream(filePath, FileMode.Create));

            return uniqueFileName;
        }

        public IEnumerable MinhasLojas(string UsuarioId) =>
            _db.Lojas.Where(p => p.UsuarioId == UsuarioId).ToList();
    }
}
