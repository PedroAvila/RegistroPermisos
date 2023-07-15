using Example.Domain.Entities;
using Example.Domain.Service;

namespace Example.Repository
{
    public class TipoPermisoRepository : BaseRepository<TipoPermiso>, ITipoPermisoRepository
    {
        public TipoPermisoRepository(RegistroPermisoContext context) : base(context) { }
        
    }
}
