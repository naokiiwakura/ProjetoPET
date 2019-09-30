using Domain.Intefaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        //BancoContext _db = new BancoContext();

        public async Task<TEntity> GetById(int id) =>
             await _db.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAll() =>
             await _db.Set<TEntity>().ToListAsync();

        public async Task Update(TEntity e)
        {
            _db.Set<TEntity>().Update(e);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(TEntity e)
        {
            _db.Set<TEntity>().Remove(e);
            await _db.SaveChangesAsync();
        }

        public async Task Add(TEntity e)
        {
            await _db.AddAsync(e);
            await _db.SaveChangesAsync();
        }
    }
}
