using Example.Domain.Entities;
using Example.Domain.Service;

namespace Example.Repository
{
    public class TypePermitRepository : BaseRepository<TypePermit>, ITTypePermitRepository
    {
        public TypePermitRepository(RegistrationPermissionContext context) : base(context) { }
        
    }
}
