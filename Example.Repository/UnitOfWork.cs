using Example.Domain.Entities;
using Example.Domain.Service;

namespace Example.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RegistrationPermissionContext _context;
        private readonly IRepository<Permission> _permisoRepository;
        private readonly IRepository<TypePermit> _tipoPermisoRepository;

        public UnitOfWork(RegistrationPermissionContext context)
        {
            _context = context;
        }

        public IRepository<Permission> PermisoRepository => _permisoRepository ?? new BaseRepository<Permission>(_context);

        public IRepository<TypePermit> TipoPermisoRepository => _tipoPermisoRepository ?? new BaseRepository<TypePermit>(_context);

        public void Dispose()
        {
            if(_context != null)
                _context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
