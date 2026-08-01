using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.Common.Interfaces
{
    public interface IContractRepository
    {
        Task<List<Contract>> GetAllAsync();
        Task<Contract?> GetByIdAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task AddAsync(Contract contract);
        void Update(Contract contract);
        void Remove(Contract contract);
    }
}
