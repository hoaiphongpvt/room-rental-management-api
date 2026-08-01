using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.Common.Interfaces
{
    public interface IPictureRepository
    {
        Task<List<Picture>> GetAllAsync();
        Task<Picture?> GetByIdAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task AddAsync(Picture picture);
        void Update(Picture picture);
        void Remove(Picture picture);
    }
}
