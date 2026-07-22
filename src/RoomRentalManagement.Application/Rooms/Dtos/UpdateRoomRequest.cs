namespace RoomRentalManagement.Application.Rooms.Dtos
{
    public class UpdateRoomRequest
    {
        public string RoomNumber { get; set; } = null!;

        public decimal Price { get; set; }

        public string Status { get; set; } = null!;

        public int MaxOccupants { get; set; }
    }
}
