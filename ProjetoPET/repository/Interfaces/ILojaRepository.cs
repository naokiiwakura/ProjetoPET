using Microsoft.AspNetCore.Http;
using ProjetoPET.Models;
using System.Threading.Tasks;

namespace ProjetoPET.repository.Interfaces
{
    public interface ILojaRepository : IRepositoryBase<Lojas>
    {
        string ConverterFoto(IFormFile e, string hosting);
    }
}
