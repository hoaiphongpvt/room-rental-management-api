using Microsoft.EntityFrameworkCore;
using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Infrastructure.Persistence.Repositories
{
    public class PictureRepository : IPictureRepository
    {
        private readonly ApplicationDBContext _context;

        public PictureRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<Picture>> GetAllAsync() => _context.Pictures.ToListAsync();

        public Task<Picture?> GetByIdAsync(Guid id) => _context.Pictures.FirstOrDefaultAsync(p => p.Id == id);

        public Task<bool> ExistsAsync(Guid id) => _context.Pictures.AnyAsync(p => p.Id == id);

        public async Task AddAsync(Picture picture) => await _context.Pictures.AddAsync(picture);

        public void Update(Picture picture) => _context.Entry(picture).State = EntityState.Modified;

        public void Remove(Picture picture) => _context.Pictures.Remove(picture);
    }
}
