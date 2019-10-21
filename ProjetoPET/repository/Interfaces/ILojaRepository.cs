using Microsoft.AspNetCore.Http;
using ProjetoPET.Models;
using System.Collections;
using System.Threading.Tasks;

namespace ProjetoPET.Repository.Interfaces
{
    public interface ILojaRepository : IRepositoryBase<Loja>
    {
        string ConverterFoto(IFormFile e, string hosting);
        IEnumerable MinhasLojas(string UsuarioId);
    }
}
