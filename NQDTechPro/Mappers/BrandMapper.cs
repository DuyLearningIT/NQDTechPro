using NQDTechPro.DTOs.Brand;
using NQDTechPro.Models;

namespace NQDTechPro.Mappers
{
    public static class BrandMapper
    {
        public static Brand ToBrand(this BrandDto brand)
        {
            return new Brand
            {
                BrandID = brand.BrandID,
                BrandName = brand.BrandName
            };
        }

        public static BrandDto ToBrandDto(this Brand brand)
        {
            return new BrandDto
            {
                BrandID = brand.BrandID,
                BrandName = brand.BrandName
            };
        }

        public static Brand FromCreateBrandToBrand(this CreateBrand brand)
        {
            return new Brand
            {
                BrandName = brand.BrandName
            };
        }

        public static BrandDto FromCreateBrandToDto(this CreateBrand brand)
        {
            return new BrandDto
            {
                BrandName = brand.BrandName,
            };
        }
    }
}
