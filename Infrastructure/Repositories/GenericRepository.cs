using Application.Interfaces.RepositoryInterfaces;
using Domain.Interfaces;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : class, IEntity<TKey>
    {
        private readonly RealDatabase _realDatabase;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(RealDatabase database)
        {
            _realDatabase = database;
            _dbSet = _realDatabase.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _realDatabase.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _realDatabase.Set<T>().Update(entity);
            await _realDatabase.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _dbSet.Remove(entity);
            await _realDatabase.SaveChangesAsync();
            return true;
        }
    }
}
