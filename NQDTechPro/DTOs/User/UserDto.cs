namespace NQDTechPro.DTOs.User
{
    public class UserDto
    {
        public int UserID { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? FullName { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Role { get; set; } = "user";

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
