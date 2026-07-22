namespace RoomRentalManagement.Domain.Entities
{
    public class Service
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal UnitPrice { get; set; }

        public string Unit { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

        public virtual ICollection<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();
    }
}
