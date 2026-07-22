namespace RoomRentalManagement.Application.Users.Dtos
{
    public class UpdateUserRequest
    {
        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string? Phone { get; set; }

        public string Role { get; set; } = null!;
    }
}
