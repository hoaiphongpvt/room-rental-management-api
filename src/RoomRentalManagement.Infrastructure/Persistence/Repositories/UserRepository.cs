using Microsoft.EntityFrameworkCore;
using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<User>> GetAllAsync() => _context.Users.ToListAsync();

        public Task<User?> GetByIdAsync(Guid id) => _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        public Task<bool> ExistsAsync(Guid id) => _context.Users.AnyAsync(u => u.Id == id);

        public async Task AddAsync(User user) => await _context.Users.AddAsync(user);

        public void Update(User user) => _context.Entry(user).State = EntityState.Modified;

        public void Remove(User user) => _context.Users.Remove(user);
    }
}
