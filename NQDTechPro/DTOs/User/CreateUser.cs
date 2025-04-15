namespace NQDTechPro.DTOs.User
{
    public class CreateUser
    {
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}