using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Task<List<Room>> GetRoomsAsync() => _roomRepository.GetAllAsync();

        public Task<Room?> GetRoomAsync(Guid id) => _roomRepository.GetByIdAsync(id);

        public async Task<Room> CreateRoomAsync(Room room)
        {
            room.Id = Guid.NewGuid();

            await _roomRepository.AddAsync(room);
            await _roomRepository.SaveChangesAsync();

            return room;
        }

        public async Task<bool> UpdateRoomAsync(Guid id, Room room)
        {
            if (id != room.Id)
            {
                throw new ArgumentException("Route id does not match room id.", nameof(id));
            }

            if (!await _roomRepository.ExistsAsync(id))
            {
                return false;
            }

            _roomRepository.Update(room);
            await _roomRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteRoomAsync(Guid id)
        {
            var room = await _roomRepository.GetByIdAsync(id);

            if (room == null)
            {
                return false;
            }

            _roomRepository.Remove(room);
            await _roomRepository.SaveChangesAsync();

            return true;
        }
    }
}
