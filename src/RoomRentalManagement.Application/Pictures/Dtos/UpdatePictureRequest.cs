namespace RoomRentalManagement.Application.Pictures.Dtos
{
    public class UpdatePictureRequest
    {
        public Guid RoomId { get; set; }

        public string Url { get; set; } = null!;

        public string? Tag { get; set; }
    }
}
