using ImpactHub.Business.Interfaces;
using ImpactHub.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ImpactHub.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ImpactHubDbContext _context;

        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ImpactHubDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        
        public async Task Add(TEntity entity)
        {
            _context.Add(entity);

            await SaveChanges();
        }
        public async Task Update(TEntity entity)
        {
            _context.Update(entity);
            await SaveChanges();
        }

        public async Task Delete(TEntity entity)
        {
            _context.Remove(entity);

            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
       
    }
}
