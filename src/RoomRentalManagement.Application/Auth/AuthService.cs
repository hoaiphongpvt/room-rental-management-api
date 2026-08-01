using RoomRentalManagement.Application.Auth.Dtos;
using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Application.Users.Dtos;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.Auth
{
    public class AuthService : IAuthService
    {
        private const string DefaultRegistrationRole = "TENANT";

        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null || !_passwordHasher.Verify(request.Password, user.Password))
            {
                return null;
            }

            var accessToken = _jwtTokenGenerator.GenerateToken(user, out var expiresAt);

            return new LoginResponse
            {
                AccessToken = accessToken,
                ExpiresAt = expiresAt,
                User = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    Phone = user.Phone,
                    Role = user.Role,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt
                }
            };
        }

        public async Task<UserDto?> RegisterAsync(RegisterRequest request)
        {
            var existing = await _userRepository.GetByEmailAsync(request.Email);

            if (existing != null)
            {
                return null;
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Password = _passwordHasher.Hash(request.Password),
                FullName = request.FullName,
                Phone = request.Phone,
                Role = DefaultRegistrationRole
            };

            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return new UserDto
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
}
