using Example.Domain.Entities;
using Example.Domain.Service;

namespace Example.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RegistroPermisoContext _context;
        private readonly IRepository<Permiso> _permisoRepository;
        private readonly IRepository<TipoPermiso> _tipoPermisoRepository;

        public UnitOfWork(RegistroPermisoContext context)
        {
            _context = context;
        }

        public IRepository<Permiso> PermisoRepository => _permisoRepository ?? new BaseRepository<Permiso>(_context);

        public IRepository<TipoPermiso> TipoPermisoRepository => _tipoPermisoRepository ?? new BaseRepository<TipoPermiso>(_context);

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
