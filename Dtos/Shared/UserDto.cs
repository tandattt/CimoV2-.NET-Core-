namespace Cimo.Dtos.Shared
{
    public class UserDto
    {
        public byte[] Id { get; set; } = null!;

        public string? AvatarUrl { get; set; }
        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
