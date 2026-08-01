using RoomRentalManagement.Application.Services.Dtos;

namespace RoomRentalManagement.Application.Services
{
    public interface IServiceService
    {
        Task<List<ServiceDto>> GetServicesAsync();
        Task<ServiceDto?> GetServiceAsync(Guid id);
        Task<ServiceDto> CreateServiceAsync(CreateServiceRequest request);
        Task<bool> UpdateServiceAsync(Guid id, UpdateServiceRequest request);
        Task<bool> DeleteServiceAsync(Guid id);
    }
}
