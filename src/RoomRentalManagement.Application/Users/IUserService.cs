using RoomRentalManagement.Application.Users.Dtos;

namespace RoomRentalManagement.Application.Users
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsersAsync();
        Task<UserDto?> GetUserAsync(Guid id);
        Task<UserDto> CreateUserAsync(CreateUserRequest request);
        Task<bool> UpdateUserAsync(Guid id, UpdateUserRequest request);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
