using System.Runtime.CompilerServices;
using NQDTechPro.DTOs.Category;

namespace NQDTechPro.Interfaces
{
    public interface ICategoryServices
    {
        Task<object> GetAllAsync();
        Task<object> GetByIdAsync(int id);
        Task<object> CreateCategoryAsync(CreateCategory cat);
        Task<object> UpdateCategoryAsync(CategoryDto cat);
        Task<object> DeleteCategoryAsync(int id);
    }
}
