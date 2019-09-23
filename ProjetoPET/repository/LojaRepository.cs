using Microsoft.AspNetCore.Http;
using ProjetoPET.Models;
using ProjetoPET.repository.Interfaces;
using System;
using System.IO;
namespace ProjetoPET.repository
{
    public class LojaRepository : RepositoryBase<Lojas>, ILojaRepository
    {

        public LojaRepository(BancoContext db) : base(db)
        {
        }

        string uniqueFileName = null;
        public string ConverterFoto(IFormFile e, string hosting)
        {
            string uploadsFolder = Path.Combine(hosting, "images/LojasPhotos");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + e.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            e.CopyTo(new FileStream(filePath, FileMode.Create));

            return uniqueFileName;
        }
    }
}
