using NQDTechPro.DTOs.Category;
using NQDTechPro.Models;

namespace NQDTechPro.Mappers
{
    public static class CategoryMapper
    {
        public static Category ToCategory(this CategoryDto cat)
        {
            return new Category
            {
                CategoryID = cat.CategoryID,
                CategoryName = cat.CategoryName,
            };
        }

        public static CategoryDto ToCategoryDto(this Category cat)
        {
            return new CategoryDto
            {
                CategoryID = cat.CategoryID,
                CategoryName = cat.CategoryName,
            };
        }
        public static Category FromCreateCategoryToCategory(this CreateCategory cat)
        {
            return new Category
            {
                CategoryName = cat.CategoryName
            };
        }
        public static CategoryDto FromCreateCategoryToDto(this CreateCategory cat)
        {
            return new CategoryDto
            {
                CategoryName = cat.CategoryName,
            };
        }
    }
}
