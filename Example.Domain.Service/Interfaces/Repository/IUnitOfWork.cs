using Example.Domain.Entities;

namespace Example.Domain.Service
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Permiso> PermisoRepository { get; }
        IRepository<TipoPermiso> TipoPermisoRepository { get; }
        Task SaveChangesAsync();
    }
}
