﻿namespace NQDTechPro.DTOs.User
{
    public class UpdateUser
    {
        public string Username { get; set; } = null!;


        public string Email { get; set; } = null!;

        public string? FullName { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
