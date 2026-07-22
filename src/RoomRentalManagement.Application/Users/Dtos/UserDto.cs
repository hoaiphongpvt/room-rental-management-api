namespace RoomRentalManagement.Application.Users.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string? Phone { get; set; }

        public string Role { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
