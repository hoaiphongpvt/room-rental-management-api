using RoomRentalManagement.Application.Pictures.Dtos;

namespace RoomRentalManagement.Application.Pictures
{
    public interface IPictureService
    {
        Task<List<PictureDto>> GetPicturesAsync();
        Task<PictureDto?> GetPictureAsync(Guid id);
        Task<PictureDto> CreatePictureAsync(CreatePictureRequest request);
        Task<bool> UpdatePictureAsync(Guid id, UpdatePictureRequest request);
        Task<bool> DeletePictureAsync(Guid id);
    }
}
