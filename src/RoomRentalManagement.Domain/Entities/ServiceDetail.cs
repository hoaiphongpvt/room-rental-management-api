namespace RoomRentalManagement.Domain.Entities
{
    public class ServiceDetail
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }

        public Guid ServiceId { get; set; }

        public string Month { get; set; } = null!;

        public decimal OldIndex { get; set; }

        public decimal NewIndex { get; set; }

        public virtual Room Room { get; set; } = null!;

        public virtual Service Service { get; set; } = null!;
    }
}
