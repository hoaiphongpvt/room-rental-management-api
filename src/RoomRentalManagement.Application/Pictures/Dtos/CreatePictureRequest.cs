namespace RoomRentalManagement.Application.Pictures.Dtos
{
    public class CreatePictureRequest
    {
        public Guid RoomId { get; set; }

        public string Url { get; set; } = null!;

        public string? Tag { get; set; }
    }
}
