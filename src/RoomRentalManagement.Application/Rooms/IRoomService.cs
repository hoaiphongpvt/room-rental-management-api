using RoomRentalManagement.Application.Rooms.Dtos;

namespace RoomRentalManagement.Application.Rooms
{
    public interface IRoomService
    {
        Task<List<RoomDto>> GetRoomsAsync();
        Task<RoomDto?> GetRoomAsync(Guid id);
        Task<RoomDto> CreateRoomAsync(CreateRoomRequest request);
        Task<bool> UpdateRoomAsync(Guid id, UpdateRoomRequest request);
        Task<bool> DeleteRoomAsync(Guid id);
    }
}
