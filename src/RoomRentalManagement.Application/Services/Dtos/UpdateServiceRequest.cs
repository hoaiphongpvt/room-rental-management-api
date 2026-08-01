namespace RoomRentalManagement.Application.Services.Dtos
{
    public class UpdateServiceRequest
    {
        public string Name { get; set; } = null!;

        public decimal UnitPrice { get; set; }

        public string Unit { get; set; } = null!;
    }
}
