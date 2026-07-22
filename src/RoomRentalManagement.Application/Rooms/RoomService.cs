using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Application.Rooms.Dtos;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IRoomRepository roomRepository, IUnitOfWork unitOfWork)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RoomDto>> GetRoomsAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();

            return rooms.Select(ToDto).ToList();
        }

        public async Task<RoomDto?> GetRoomAsync(Guid id)
        {
            var room = await _roomRepository.GetByIdAsync(id);

            return room == null ? null : ToDto(room);
        }

        public async Task<RoomDto> CreateRoomAsync(CreateRoomRequest request)
        {
            var room = new Room
            {
                Id = Guid.NewGuid(),
                RoomNumber = request.RoomNumber,
                Price = request.Price,
                Status = request.Status,
                MaxOccupants = request.MaxOccupants
            };

            await _roomRepository.AddAsync(room);
            await _unitOfWork.SaveChangesAsync();

            return ToDto(room);
        }

        public async Task<bool> UpdateRoomAsync(Guid id, UpdateRoomRequest request)
        {
            var room = await _roomRepository.GetByIdAsync(id);

            if (room == null)
            {
                return false;
            }

            room.RoomNumber = request.RoomNumber;
            room.Price = request.Price;
            room.Status = request.Status;
            room.MaxOccupants = request.MaxOccupants;

            _roomRepository.Update(room);
            await _unitOfWork.SaveChangesAsync();

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
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        private static RoomDto ToDto(Room room) => new()
        {
            Id = room.Id,
            RoomNumber = room.RoomNumber,
            Price = room.Price,
            Status = room.Status,
            MaxOccupants = room.MaxOccupants,
            CreatedAt = room.CreatedAt,
            UpdatedAt = room.UpdatedAt
        };
    }
}
