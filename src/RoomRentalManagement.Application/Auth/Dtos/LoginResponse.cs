using RoomRentalManagement.Application.Users.Dtos;

namespace RoomRentalManagement.Application.Auth.Dtos
{
    public class LoginResponse
    {
        public string AccessToken { get; set; } = null!;

        public DateTime ExpiresAt { get; set; }

        public UserDto User { get; set; } = null!;
    }
}
