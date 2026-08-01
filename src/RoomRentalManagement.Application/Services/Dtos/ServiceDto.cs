namespace RoomRentalManagement.Application.Services.Dtos
{
    public class ServiceDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal UnitPrice { get; set; }

        public string Unit { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
