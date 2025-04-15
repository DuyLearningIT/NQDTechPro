using NQDTechPro.DTOs.Product;

namespace NQDTechPro.Interfaces
{
    public interface IProductServices
    {
        Task<object> GetAllAsync();
        Task<object> GetByCategoryIdAsync(int categoryId);
        Task<object> GetByBrandIdAsync(int brandId);
        Task<object> GetByIdAsync(int proid);

        Task<object> CreateProductAsync(CreateProduct pro);
        Task<object> UpdateProductAsync(ProductDto pro);
        Task<object> DeleteProductAsync(int proid);

    }
}
