using Microsoft.EntityFrameworkCore;
using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Infrastructure.Persistence.Repositories
{
    public class ServiceDetailRepository : IServiceDetailRepository
    {
        private readonly ApplicationDBContext _context;

        public ServiceDetailRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<ServiceDetail>> GetAllAsync() => _context.ServiceDetails.ToListAsync();

        public Task<ServiceDetail?> GetByIdAsync(Guid id) => _context.ServiceDetails.FirstOrDefaultAsync(s => s.Id == id);

        public Task<bool> ExistsAsync(Guid id) => _context.ServiceDetails.AnyAsync(s => s.Id == id);

        public async Task AddAsync(ServiceDetail serviceDetail) => await _context.ServiceDetails.AddAsync(serviceDetail);

        public void Update(ServiceDetail serviceDetail) => _context.Entry(serviceDetail).State = EntityState.Modified;

        public void Remove(ServiceDetail serviceDetail) => _context.ServiceDetails.Remove(serviceDetail);
    }
}
