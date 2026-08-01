using Microsoft.EntityFrameworkCore;
using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Infrastructure.Persistence.Repositories
{
    public class InvoiceDetailRepository : IInvoiceDetailRepository
    {
        private readonly ApplicationDBContext _context;

        public InvoiceDetailRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<InvoiceDetail>> GetAllAsync() => _context.InvoiceDetails.ToListAsync();

        public Task<InvoiceDetail?> GetByIdAsync(Guid id) => _context.InvoiceDetails.FirstOrDefaultAsync(d => d.Id == id);

        public Task<bool> ExistsAsync(Guid id) => _context.InvoiceDetails.AnyAsync(d => d.Id == id);

        public async Task AddAsync(InvoiceDetail invoiceDetail) => await _context.InvoiceDetails.AddAsync(invoiceDetail);

        public void Update(InvoiceDetail invoiceDetail) => _context.Entry(invoiceDetail).State = EntityState.Modified;

        public void Remove(InvoiceDetail invoiceDetail) => _context.InvoiceDetails.Remove(invoiceDetail);
    }
}
