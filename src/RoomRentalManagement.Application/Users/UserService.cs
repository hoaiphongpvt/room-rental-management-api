using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Application.Users.Dtos;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(ToDto).ToList();
        }

        public async Task<UserDto?> GetUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            return user == null ? null : ToDto(user);
        }

        public async Task<UserDto> CreateUserAsync(CreateUserRequest request)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Password = _passwordHasher.Hash(request.Password),
                FullName = request.FullName,
                Phone = request.Phone,
                Role = request.Role
            };

            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return ToDto(user);
        }

        public async Task<bool> UpdateUserAsync(Guid id, UpdateUserRequest request)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return false;
            }

            user.Email = request.Email;
            user.FullName = request.FullName;
            user.Phone = request.Phone;
            user.Role = request.Role;

            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return false;
            }

            _userRepository.Remove(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        private static UserDto ToDto(User user) => new()
        {
            Id = user.Id,
            Email = user.Email,
            FullName = user.FullName,
            Phone = user.Phone,
            Role = user.Role,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }
}
