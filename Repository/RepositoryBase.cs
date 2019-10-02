using Data;
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly BancoContext _db;
        public RepositoryBase() =>
            _db = new BancoContext();

        public async Task<TEntity> GetById(int id) =>
             await _db.Set<TEntity>().FindAsync(id);

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

        public async Task<IEnumerable<TEntity>> GetAll() =>
             await _db.Set<TEntity>().ToListAsync();
    }
}
