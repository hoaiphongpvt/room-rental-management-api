using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.Common.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user, out DateTime expiresAt);
    }
}
