using RoomRentalManagement.Application.ServiceDetails.Dtos;

namespace RoomRentalManagement.Application.ServiceDetails
{
    public interface IServiceDetailService
    {
        Task<List<ServiceDetailDto>> GetServiceDetailsAsync();
        Task<ServiceDetailDto?> GetServiceDetailAsync(Guid id);
        Task<ServiceDetailDto> CreateServiceDetailAsync(CreateServiceDetailRequest request);
        Task<bool> UpdateServiceDetailAsync(Guid id, UpdateServiceDetailRequest request);
        Task<bool> DeleteServiceDetailAsync(Guid id);
    }
}
