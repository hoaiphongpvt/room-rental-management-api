namespace RoomRentalManagement.Application.ServiceDetails.Dtos
{
    public class CreateServiceDetailRequest
    {
        public Guid RoomId { get; set; }

        public Guid ServiceId { get; set; }

        public string Month { get; set; } = null!;

        public decimal OldIndex { get; set; }

        public decimal NewIndex { get; set; }
    }
}
