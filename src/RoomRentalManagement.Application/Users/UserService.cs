using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<User>> GetUsersAsync() => _userRepository.GetAllAsync();

        public Task<User?> GetUserAsync(Guid id) => _userRepository.GetByIdAsync(id);

        public async Task<User> CreateUserAsync(User user)
        {
            user.Id = Guid.NewGuid();

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UpdateUserAsync(Guid id, User user)
        {
            if (id != user.Id)
            {
                throw new ArgumentException("Route id does not match user id.", nameof(id));
            }

            if (!await _userRepository.ExistsAsync(id))
            {
                return false;
            }

            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();

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
            await _userRepository.SaveChangesAsync();

            return true;
        }
    }
}
