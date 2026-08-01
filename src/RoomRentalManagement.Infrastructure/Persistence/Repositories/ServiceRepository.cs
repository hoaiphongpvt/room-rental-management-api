using Microsoft.EntityFrameworkCore;
using RoomRentalManagement.Application.Common.Interfaces;
using ServiceEntity = RoomRentalManagement.Domain.Entities.Service;

namespace RoomRentalManagement.Infrastructure.Persistence.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDBContext _context;

        public ServiceRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<ServiceEntity>> GetAllAsync() => _context.Services.ToListAsync();

        public Task<ServiceEntity?> GetByIdAsync(Guid id) => _context.Services.FirstOrDefaultAsync(s => s.Id == id);

        public Task<bool> ExistsAsync(Guid id) => _context.Services.AnyAsync(s => s.Id == id);

        public async Task AddAsync(ServiceEntity service) => await _context.Services.AddAsync(service);

        public void Update(ServiceEntity service) => _context.Entry(service).State = EntityState.Modified;

        public void Remove(ServiceEntity service) => _context.Services.Remove(service);
    }
}
