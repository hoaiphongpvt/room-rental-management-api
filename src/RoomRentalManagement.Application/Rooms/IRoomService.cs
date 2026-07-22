using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.Rooms
{
    public interface IRoomService
    {
        Task<List<Room>> GetRoomsAsync();
        Task<Room?> GetRoomAsync(Guid id);
        Task<Room> CreateRoomAsync(Room room);
        Task<bool> UpdateRoomAsync(Guid id, Room room);
        Task<bool> DeleteRoomAsync(Guid id);
    }
}
