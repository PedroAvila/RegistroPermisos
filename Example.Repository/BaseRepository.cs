using Example.Domain.Service;
using Microsoft.EntityFrameworkCore;

namespace Example.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly RegistrationPermissionContext _context;

        public BaseRepository(RegistrationPermissionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
