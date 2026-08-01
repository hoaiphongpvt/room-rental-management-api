using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.Common.Interfaces
{
    public interface IServiceDetailRepository
    {
        Task<List<ServiceDetail>> GetAllAsync();
        Task<ServiceDetail?> GetByIdAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task AddAsync(ServiceDetail serviceDetail);
        void Update(ServiceDetail serviceDetail);
        void Remove(ServiceDetail serviceDetail);
    }
}
