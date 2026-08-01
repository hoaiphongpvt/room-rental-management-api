using RoomRentalManagement.Application.Auth.Dtos;
using RoomRentalManagement.Application.Users.Dtos;

namespace RoomRentalManagement.Application.Auth
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(LoginRequest request);
        Task<UserDto?> RegisterAsync(RegisterRequest request);
    }
}
