namespace RoomRentalManagement.Application.Rooms.Dtos
{
    public class RoomDto
    {
        public Guid Id { get; set; }

        public string RoomNumber { get; set; } = null!;

        public decimal Price { get; set; }

        public string Status { get; set; } = null!;

        public int MaxOccupants { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
