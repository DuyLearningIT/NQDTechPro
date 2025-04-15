using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using NQDTechPro.DTOs.Product;
using NQDTechPro.Models;

namespace NQDTechPro.Mappers
{
    public static class ProductMapper
    {
        public static Product ToProduct(this ProductDto pro)
        {
            return new Product
            {
                ProductName = pro.ProductName,
                CategoryID = pro.CategoryID,
                BrandID = pro.CategoryID,
                Description = pro.Description,
                Price = pro.Price,
                ImageURL = pro.ImageURL,
                Quantity = pro.Quantity,
                CPU = pro.CPU,
                RAM = pro.RAM,
                Storage = pro.Storage,
                Screen = pro.Screen,
                GraphicsCard = pro.GraphicsCard,
                OperatingSystem = pro.OperatingSystem,
                Weight = pro.Weight,
            };
        }
        public static ProductDto ToProductDto(this Product product) {
        
                return new ProductDto
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    CategoryID = product.CategoryID,
                    BrandID = product.BrandID,
                    Description = product.Description,
                    Price = product.Price,
                    ImageURL = product.ImageURL,
                    CPU = product.CPU,
                    RAM = product.RAM,
                    Storage = product.Storage,
                    Screen = product.Screen,
                    GraphicsCard = product.GraphicsCard,
                    OperatingSystem = product.OperatingSystem,
                    Weight = product.Weight,
                    Quantity = product.Quantity
                };
        }
        public static ProductDto FromCreateProductToDto(this CreateProduct product)
        {
            return new ProductDto
            {
                ProductName = product.ProductName,
                CategoryID = product.CategoryID,
                BrandID = product.BrandID,
                Description = product.Description,
                Price = product.Price,
                ImageURL = product.ImageURL,
                CPU = product.CPU,
                RAM = product.RAM,
                Storage = product.Storage,
                Screen = product.Screen,
                GraphicsCard = product.GraphicsCard,
                OperatingSystem = product.OperatingSystem,
                Weight = product.Weight,
                Quantity = product.Quantity
            };
        }
        public static Product FromCreateProductToProduct(this CreateProduct product)
        {
            return new Product
            {
                ProductName = product.ProductName,
                CategoryID = product.CategoryID,
                BrandID = product.BrandID,
                Description = product.Description,
                Price = product.Price,
                ImageURL = product.ImageURL,
                CPU = product.CPU,
                RAM = product.RAM,
                Storage = product.Storage,
                Screen = product.Screen,
                GraphicsCard = product.GraphicsCard,
                OperatingSystem = product.OperatingSystem,
                Weight = product.Weight,
                Quantity = product.Quantity
            };
        }
    }
}
