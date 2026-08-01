using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.Common.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetAllAsync();
        Task<Invoice?> GetByIdAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task AddAsync(Invoice invoice);
        void Update(Invoice invoice);
        void Remove(Invoice invoice);
    }
}
