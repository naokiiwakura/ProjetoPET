using Microsoft.EntityFrameworkCore;
using ProjetoPET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProjetoPET.repository
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : class, IEntity
    {
        private readonly BancoContext _db;
        public GenericRepository(BancoContext db)
        {
            _db = db;
        }
        public async Task<Tentity> BuscarPorId(int id)
        {
            return await _db.Set<Tentity>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Editar(int id, Tentity e)
        {

            e.UpdatedData = DateTime.Now;
            _db.Set<Tentity>().Update(e);
            _db.Entry(e).Property(x => x.CreatedDate).IsModified = false;
            await _db.SaveChangesAsync();

        }

        public async Task Excluir(int id)
        {
            var procura = await BuscarPorId(id);
            _db.Set<Tentity>().Remove(procura);
            await _db.SaveChangesAsync();

        }

        public async Task<bool> Existe(int id)
        {
            return await _db.Set<Tentity>().AnyAsync(e => e.Id == id);
        }

        public async Task Inserir(Tentity e)
        {
            e.CreatedDate = DateTime.Now;
            await _db.Set<Tentity>().AddAsync(e);
            await _db.SaveChangesAsync();
        }

        public async Task<IList<Tentity>> ListarTodos()
        {
            return await _db.Set<Tentity>().ToListAsync();
        }
    }
}
