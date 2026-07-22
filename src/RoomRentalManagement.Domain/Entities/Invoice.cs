namespace RoomRentalManagement.Domain.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }

        public Guid ContractId { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = null!;

        public DateOnly DueDate { get; set; }

        public virtual Contract Contract { get; set; } = null!;

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
    }
}
