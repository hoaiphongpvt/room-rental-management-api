using Microsoft.EntityFrameworkCore;
using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Infrastructure.Persistence.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDBContext _context;

        public RoomRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<Room>> GetAllAsync() => _context.Rooms.ToListAsync();

        public Task<Room?> GetByIdAsync(Guid id) => _context.Rooms.FirstOrDefaultAsync(r => r.Id == id);

        public Task<bool> ExistsAsync(Guid id) => _context.Rooms.AnyAsync(r => r.Id == id);

        public async Task AddAsync(Room room) => await _context.Rooms.AddAsync(room);

        public void Update(Room room) => _context.Entry(room).State = EntityState.Modified;

        public void Remove(Room room) => _context.Rooms.Remove(room);
    }
}
