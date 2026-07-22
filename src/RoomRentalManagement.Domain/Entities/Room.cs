namespace RoomRentalManagement.Domain.Entities
{
    public class Room
    {
        public Guid Id { get; set; }

        public string RoomNumber { get; set; } = null!;

        public decimal Price { get; set; }

        public string Status { get; set; } = null!;

        public int MaxOccupants { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

        public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();

        public virtual ICollection<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();
    }
}
