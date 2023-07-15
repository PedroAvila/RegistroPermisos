using Example.Domain.Entities;
using Example.Domain.Service;

namespace Example.Repository
{
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(RegistrationPermissionContext context) : base(context) { }
        
    }
}
