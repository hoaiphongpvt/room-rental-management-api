using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.Common.Interfaces
{
    public interface IInvoiceDetailRepository
    {
        Task<List<InvoiceDetail>> GetAllAsync();
        Task<InvoiceDetail?> GetByIdAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task AddAsync(InvoiceDetail invoiceDetail);
        void Update(InvoiceDetail invoiceDetail);
        void Remove(InvoiceDetail invoiceDetail);
    }
}
