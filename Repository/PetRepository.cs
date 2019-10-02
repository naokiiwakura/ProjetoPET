using Domain.Interface.Repository;
using Domain.Model;

namespace Repository
{
    public class PetRepository : RepositoryBase<Pet>, IPetRepository
    {
    }
}
