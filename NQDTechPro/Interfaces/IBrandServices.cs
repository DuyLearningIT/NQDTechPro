using NQDTechPro.DTOs.Brand;
using NQDTechPro.Models;

namespace NQDTechPro.Interfaces
{
    public interface IBrandServices
    {
        Task<object> GetAllAsync();
        Task<object> GetByIdAsync(int brandId);
        Task<object> CreateBrandAsync(CreateBrand brand);
        Task<object> UpdateBrand(BrandDto brand);
        Task<object> DeleteBrandAsync(int brandId);
    }
}
