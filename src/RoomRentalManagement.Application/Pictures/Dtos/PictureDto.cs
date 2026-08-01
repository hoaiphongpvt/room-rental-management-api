namespace RoomRentalManagement.Application.Pictures.Dtos
{
    public class PictureDto
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }

        public string Url { get; set; } = null!;

        public string? Tag { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
