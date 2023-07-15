using Example.Domain.Entities;
using Example.Domain.Service;

namespace Example.Repository
{
    public class PermisoRepository : BaseRepository<Permiso>, IPermisoRepository
    {
        public PermisoRepository(RegistroPermisoContext context) : base(context) { }
        
    }
}
