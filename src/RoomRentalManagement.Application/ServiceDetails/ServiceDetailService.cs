using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Application.ServiceDetails.Dtos;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.ServiceDetails
{
    public class ServiceDetailService : IServiceDetailService
    {
        private readonly IServiceDetailRepository _serviceDetailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceDetailService(IServiceDetailRepository serviceDetailRepository, IUnitOfWork unitOfWork)
        {
            _serviceDetailRepository = serviceDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ServiceDetailDto>> GetServiceDetailsAsync()
        {
            var serviceDetails = await _serviceDetailRepository.GetAllAsync();

            return serviceDetails.Select(ToDto).ToList();
        }

        public async Task<ServiceDetailDto?> GetServiceDetailAsync(Guid id)
        {
            var serviceDetail = await _serviceDetailRepository.GetByIdAsync(id);

            return serviceDetail == null ? null : ToDto(serviceDetail);
        }

        public async Task<ServiceDetailDto> CreateServiceDetailAsync(CreateServiceDetailRequest request)
        {
            var serviceDetail = new ServiceDetail
            {
                Id = Guid.NewGuid(),
                RoomId = request.RoomId,
                ServiceId = request.ServiceId,
                Month = request.Month,
                OldIndex = request.OldIndex,
                NewIndex = request.NewIndex
            };

            await _serviceDetailRepository.AddAsync(serviceDetail);
            await _unitOfWork.SaveChangesAsync();

            return ToDto(serviceDetail);
        }

        public async Task<bool> UpdateServiceDetailAsync(Guid id, UpdateServiceDetailRequest request)
        {
            var serviceDetail = await _serviceDetailRepository.GetByIdAsync(id);

            if (serviceDetail == null)
            {
                return false;
            }

            serviceDetail.RoomId = request.RoomId;
            serviceDetail.ServiceId = request.ServiceId;
            serviceDetail.Month = request.Month;
            serviceDetail.OldIndex = request.OldIndex;
            serviceDetail.NewIndex = request.NewIndex;

            _serviceDetailRepository.Update(serviceDetail);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteServiceDetailAsync(Guid id)
        {
            var serviceDetail = await _serviceDetailRepository.GetByIdAsync(id);

            if (serviceDetail == null)
            {
                return false;
            }

            _serviceDetailRepository.Remove(serviceDetail);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        private static ServiceDetailDto ToDto(ServiceDetail serviceDetail) => new()
        {
            Id = serviceDetail.Id,
            RoomId = serviceDetail.RoomId,
            ServiceId = serviceDetail.ServiceId,
            Month = serviceDetail.Month,
            OldIndex = serviceDetail.OldIndex,
            NewIndex = serviceDetail.NewIndex
        };
    }
}
