using NQDTechPro.DTOs.User;

namespace NQDTechPro.Interfaces
{
    public interface IUserServices
    {
        Task<object> GetAllAsync();
        Task<object> GetByIdAsync(int UserId);
        Task<object> CreateUserAsync(CreateUser user);
        Task<object> UpdateUserAsync(UpdateUser user);
        Task<object> DeleteUserAsync(int UserId);
        Task<object> LoginAsync(LoginUser user);
    }
}
