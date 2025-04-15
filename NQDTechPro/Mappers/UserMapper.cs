using System.Net.NetworkInformation;
using NQDTechPro.DTOs.User;
using NQDTechPro.Models;

namespace NQDTechPro.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this UserDto user)
        {
            return new User
            {
                UserID = user.UserID,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                FullName = user.FullName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };
        }
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                UserID = user.UserID,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                FullName = user.FullName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };
        }
        public static User FromCreateToUser(this CreateUser user)
        {
            return new User
            {
                Username = user.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                Email = user.Email
            };
        }
    }
}
