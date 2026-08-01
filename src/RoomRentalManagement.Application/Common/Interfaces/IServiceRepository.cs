using ServiceEntity = RoomRentalManagement.Domain.Entities.Service;

namespace RoomRentalManagement.Application.Common.Interfaces
{
    public interface IServiceRepository
    {
        Task<List<ServiceEntity>> GetAllAsync();
        Task<ServiceEntity?> GetByIdAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task AddAsync(ServiceEntity service);
        void Update(ServiceEntity service);
        void Remove(ServiceEntity service);
    }
}
