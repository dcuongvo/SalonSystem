using Microsoft.EntityFrameworkCore;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Base.Implementations
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
                return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
