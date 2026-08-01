using RoomRentalManagement.Application.InvoiceDetails.Dtos;

namespace RoomRentalManagement.Application.InvoiceDetails
{
    public interface IInvoiceDetailService
    {
        Task<List<InvoiceDetailDto>> GetInvoiceDetailsAsync();
        Task<InvoiceDetailDto?> GetInvoiceDetailAsync(Guid id);
        Task<InvoiceDetailDto> CreateInvoiceDetailAsync(CreateInvoiceDetailRequest request);
        Task<bool> UpdateInvoiceDetailAsync(Guid id, UpdateInvoiceDetailRequest request);
        Task<bool> DeleteInvoiceDetailAsync(Guid id);
    }
}
