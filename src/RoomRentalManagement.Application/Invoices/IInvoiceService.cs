using RoomRentalManagement.Application.Invoices.Dtos;

namespace RoomRentalManagement.Application.Invoices
{
    public interface IInvoiceService
    {
        Task<List<InvoiceDto>> GetInvoicesAsync();
        Task<InvoiceDto?> GetInvoiceAsync(Guid id);
        Task<InvoiceDto> CreateInvoiceAsync(CreateInvoiceRequest request);
        Task<bool> UpdateInvoiceAsync(Guid id, UpdateInvoiceRequest request);
        Task<bool> DeleteInvoiceAsync(Guid id);
    }
}
