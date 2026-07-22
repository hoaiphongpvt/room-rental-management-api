namespace RoomRentalManagement.Domain.Entities
{
    public class Picture
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }

        public string Url { get; set; } = null!;

        public string? Tag { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public virtual Room Room { get; set; } = null!;
    }
}
