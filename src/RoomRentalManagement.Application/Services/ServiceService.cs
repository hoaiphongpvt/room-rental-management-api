using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Application.Services.Dtos;
using ServiceEntity = RoomRentalManagement.Domain.Entities.Service;

namespace RoomRentalManagement.Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceService(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ServiceDto>> GetServicesAsync()
        {
            var services = await _serviceRepository.GetAllAsync();

            return services.Select(ToDto).ToList();
        }

        public async Task<ServiceDto?> GetServiceAsync(Guid id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);

            return service == null ? null : ToDto(service);
        }

        public async Task<ServiceDto> CreateServiceAsync(CreateServiceRequest request)
        {
            var service = new ServiceEntity
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                UnitPrice = request.UnitPrice,
                Unit = request.Unit
            };

            await _serviceRepository.AddAsync(service);
            await _unitOfWork.SaveChangesAsync();

            return ToDto(service);
        }

        public async Task<bool> UpdateServiceAsync(Guid id, UpdateServiceRequest request)
        {
            var service = await _serviceRepository.GetByIdAsync(id);

            if (service == null)
            {
                return false;
            }

            service.Name = request.Name;
            service.UnitPrice = request.UnitPrice;
            service.Unit = request.Unit;

            _serviceRepository.Update(service);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteServiceAsync(Guid id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);

            if (service == null)
            {
                return false;
            }

            _serviceRepository.Remove(service);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        private static ServiceDto ToDto(ServiceEntity service) => new()
        {
            Id = service.Id,
            Name = service.Name,
            UnitPrice = service.UnitPrice,
            Unit = service.Unit,
            CreatedAt = service.CreatedAt,
            UpdatedAt = service.UpdatedAt
        };
    }
}
