using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Application.InvoiceDetails.Dtos;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.InvoiceDetails
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceDetailService(IInvoiceDetailRepository invoiceDetailRepository, IUnitOfWork unitOfWork)
        {
            _invoiceDetailRepository = invoiceDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<InvoiceDetailDto>> GetInvoiceDetailsAsync()
        {
            var invoiceDetails = await _invoiceDetailRepository.GetAllAsync();

            return invoiceDetails.Select(ToDto).ToList();
        }

        public async Task<InvoiceDetailDto?> GetInvoiceDetailAsync(Guid id)
        {
            var invoiceDetail = await _invoiceDetailRepository.GetByIdAsync(id);

            return invoiceDetail == null ? null : ToDto(invoiceDetail);
        }

        public async Task<InvoiceDetailDto> CreateInvoiceDetailAsync(CreateInvoiceDetailRequest request)
        {
            var invoiceDetail = new InvoiceDetail
            {
                Id = Guid.NewGuid(),
                InvoiceId = request.InvoiceId,
                ServiceId = request.ServiceId,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
                Amount = request.Amount
            };

            await _invoiceDetailRepository.AddAsync(invoiceDetail);
            await _unitOfWork.SaveChangesAsync();

            return ToDto(invoiceDetail);
        }

        public async Task<bool> UpdateInvoiceDetailAsync(Guid id, UpdateInvoiceDetailRequest request)
        {
            var invoiceDetail = await _invoiceDetailRepository.GetByIdAsync(id);

            if (invoiceDetail == null)
            {
                return false;
            }

            invoiceDetail.InvoiceId = request.InvoiceId;
            invoiceDetail.ServiceId = request.ServiceId;
            invoiceDetail.Quantity = request.Quantity;
            invoiceDetail.UnitPrice = request.UnitPrice;
            invoiceDetail.Amount = request.Amount;

            _invoiceDetailRepository.Update(invoiceDetail);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteInvoiceDetailAsync(Guid id)
        {
            var invoiceDetail = await _invoiceDetailRepository.GetByIdAsync(id);

            if (invoiceDetail == null)
            {
                return false;
            }

            _invoiceDetailRepository.Remove(invoiceDetail);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        private static InvoiceDetailDto ToDto(InvoiceDetail invoiceDetail) => new()
        {
            Id = invoiceDetail.Id,
            InvoiceId = invoiceDetail.InvoiceId,
            ServiceId = invoiceDetail.ServiceId,
            Quantity = invoiceDetail.Quantity,
            UnitPrice = invoiceDetail.UnitPrice,
            Amount = invoiceDetail.Amount
        };
    }
}
