namespace RoomRentalManagement.Application.Auth.Dtos
{
    public class RegisterRequest
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string? Phone { get; set; }
    }
}
