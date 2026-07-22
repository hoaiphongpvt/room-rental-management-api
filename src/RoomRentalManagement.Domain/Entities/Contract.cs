namespace RoomRentalManagement.Domain.Entities
{
    public class Contract
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }

        public Guid CustomerId { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public decimal Deposit { get; set; }

        public decimal MonthlyRent { get; set; }

        public string Status { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public virtual User Customer { get; set; } = null!;

        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

        public virtual Room Room { get; set; } = null!;
    }
}
