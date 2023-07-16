using Example.Domain.Entities;

namespace Example.Domain.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PermissionService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Permission entity)
        {
            await _unitOfWork.PermissionRepository.CreateAsync(entity);
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            return await _unitOfWork.PermissionRepository.GetAllAsync();
        }

        public async Task<Permission> GetByIdAsync(int id)
        {
            return await _unitOfWork.PermissionRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Permission entity)
        {
            await _unitOfWork.PermissionRepository.UpdateAsync(entity);
        }
    }
}
