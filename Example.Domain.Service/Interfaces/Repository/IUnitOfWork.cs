using Example.Domain.Entities;

namespace Example.Domain.Service
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Permission> PermisoRepository { get; }
        IRepository<TypePermit> TipoPermisoRepository { get; }
        Task SaveChangesAsync();
    }
}
