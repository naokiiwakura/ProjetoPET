using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoPET.repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Add(TEntity e);
        Task Update(TEntity e);
        Task Delete(TEntity e);
    }
}
