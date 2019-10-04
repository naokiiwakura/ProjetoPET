using Domain.Interface.Repository;
using Domain.Model;

namespace Repository
{
    public class AnuncioRepository : RepositoryBase<Anuncio>, IAnuncioRepository
    {
    }
}