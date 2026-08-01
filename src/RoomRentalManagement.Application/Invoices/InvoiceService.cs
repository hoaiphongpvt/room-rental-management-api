using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Application.Invoices.Dtos;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<InvoiceDto>> GetInvoicesAsync()
        {
            var invoices = await _invoiceRepository.GetAllAsync();

            return invoices.Select(ToDto).ToList();
        }

        public async Task<InvoiceDto?> GetInvoiceAsync(Guid id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);

            return invoice == null ? null : ToDto(invoice);
        }

        public async Task<InvoiceDto> CreateInvoiceAsync(CreateInvoiceRequest request)
        {
            var invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                ContractId = request.ContractId,
                Month = request.Month,
                Year = request.Year,
                TotalAmount = request.TotalAmount,
                Status = request.Status,
                DueDate = request.DueDate
            };

            await _invoiceRepository.AddAsync(invoice);
            await _unitOfWork.SaveChangesAsync();

            return ToDto(invoice);
        }

        public async Task<bool> UpdateInvoiceAsync(Guid id, UpdateInvoiceRequest request)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);

            if (invoice == null)
            {
                return false;
            }

            invoice.ContractId = request.ContractId;
            invoice.Month = request.Month;
            invoice.Year = request.Year;
            invoice.TotalAmount = request.TotalAmount;
            invoice.Status = request.Status;
            invoice.DueDate = request.DueDate;

            _invoiceRepository.Update(invoice);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteInvoiceAsync(Guid id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);

            if (invoice == null)
            {
                return false;
            }

            _invoiceRepository.Remove(invoice);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        private static InvoiceDto ToDto(Invoice invoice) => new()
        {
            Id = invoice.Id,
            ContractId = invoice.ContractId,
            Month = invoice.Month,
            Year = invoice.Year,
            TotalAmount = invoice.TotalAmount,
            Status = invoice.Status,
            DueDate = invoice.DueDate
        };
    }
}
