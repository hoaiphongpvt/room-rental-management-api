using Microsoft.EntityFrameworkCore;
using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Infrastructure.Persistence.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly ApplicationDBContext _context;

        public ContractRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<Contract>> GetAllAsync() => _context.Contracts.ToListAsync();

        public Task<Contract?> GetByIdAsync(Guid id) => _context.Contracts.FirstOrDefaultAsync(c => c.Id == id);

        public Task<bool> ExistsAsync(Guid id) => _context.Contracts.AnyAsync(c => c.Id == id);

        public async Task AddAsync(Contract contract) => await _context.Contracts.AddAsync(contract);

        public void Update(Contract contract) => _context.Entry(contract).State = EntityState.Modified;

        public void Remove(Contract contract) => _context.Contracts.Remove(contract);
    }
}
