using Microsoft.AspNetCore.Http;
using ProjetoPET.Models;

namespace ProjetoPET.Repository.Interfaces
{
    public interface ILojaRepository : IRepositoryBase<Loja>
    {
        string ConverterFoto(IFormFile e, string hosting);
    }
}
