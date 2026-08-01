using Microsoft.EntityFrameworkCore;
using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Infrastructure.Persistence.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDBContext _context;

        public InvoiceRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<Invoice>> GetAllAsync() => _context.Invoices.ToListAsync();

        public Task<Invoice?> GetByIdAsync(Guid id) => _context.Invoices.FirstOrDefaultAsync(i => i.Id == id);

        public Task<bool> ExistsAsync(Guid id) => _context.Invoices.AnyAsync(i => i.Id == id);

        public async Task AddAsync(Invoice invoice) => await _context.Invoices.AddAsync(invoice);

        public void Update(Invoice invoice) => _context.Entry(invoice).State = EntityState.Modified;

        public void Remove(Invoice invoice) => _context.Invoices.Remove(invoice);
    }
}
