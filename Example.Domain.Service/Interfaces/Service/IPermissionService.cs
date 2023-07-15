using Example.Domain.Entities;

namespace Example.Domain.Service
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetAllAsync();
        Task<Permission> GetByIdAsync(int id);
        Task CreateAsync(Permission entity);
        Task UpdateAsync(Permission entity);
    }
}
