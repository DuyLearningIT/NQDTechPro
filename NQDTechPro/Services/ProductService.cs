using System.Net;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using NQDTechPro.Data;
using NQDTechPro.DTOs.Product;
using NQDTechPro.Interfaces;
using NQDTechPro.Mappers;
using NQDTechPro.Models;

namespace NQDTechPro.Services
{
    public class ProductService : IProductServices
    {
        private readonly dbContext _dbContext;
        public ProductService(dbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<object> CreateProductAsync(CreateProduct pro)
        {
            try
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(_ => _.ProductName == pro.ProductName);
                if (product != null)
                    return new { httpStatuscode = HttpStatusCode.BadRequest, mess = "Đã tồn tại sản phẩm này !" };

                await _dbContext.Products.AddAsync(pro.FromCreateProductToProduct());
                await _dbContext.SaveChangesAsync();
                return new { httpStatusCode = HttpStatusCode.Created, mess = "Tạo sản phẩm thành công !", data = pro };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> DeleteProductAsync(int proid)
        {
            try
            {
                var pro = await _dbContext.Products.FindAsync(proid);
                if (pro == null)
                {
                    return new { httpStatusCode = HttpStatusCode.NotFound, mess = "Không tồn tại sản phẩm !" };
                }
                _dbContext.Products.Remove(pro);
                await _dbContext.SaveChangesAsync();
                return new { httpStatusCode = HttpStatusCode.NoContent, mess = "Xóa sản phẩm thành công !" };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }

        }

        public async Task<object> GetAllAsync()
        {
            try
            {
                var pros = await _dbContext.Products.ToListAsync();
                var data = pros.Select(_ => _.ToProductDto()); 
                return new {httpStatusCode =  HttpStatusCode.OK, data = data, mess="Lấy tất cả sản phẩm thành công !" };
            }
            catch (Exception ex)
            {
                return new {httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message};
            }
        }

        public async Task<object> GetByBrandIdAsync(int brandId)
        {
            try
            {
                var pros = await _dbContext.Products.Where(_ => _.BrandID == brandId).ToListAsync();
                var data = pros.Select(_ => _.ToProductDto());

                return new { httpStatusCode = HttpStatusCode.OK, mess = "Lấy sản phẩm thành công !", data = data };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> GetByCategoryIdAsync(int categoryId)
        {
            try
            {
                var pros = await _dbContext.Products.Where(_ => _.CategoryID == categoryId).ToListAsync();
                var data = pros.Select(_ => _.ToProductDto());

                return new { httpStatusCode = HttpStatusCode.OK, mess = "Lấy sản phẩm thành công !", data = data };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> GetByIdAsync(int proid)
        {
            try
            {
                var pro = await _dbContext.Products.FindAsync(proid);
                if (pro == null)
                    return new { httpStatusCode = HttpStatusCode.NotFound, mess = "Không tìm thấy sản phẩm !" };
                return new { httpStatusCode = HttpStatusCode.OK, mess = "Tìm sản phẩm thành công !", data = pro.ToProductDto() };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> UpdateProductAsync(ProductDto pro)
        {
            try
            {
                var check = await _dbContext.Products.FirstOrDefaultAsync(_ => _.ProductID == pro.ProductID);
                if (check == null)
                    return new { httpStatusCode = HttpStatusCode.NotFound, mess = "Không tìm thấy sản phẩm !" };

                check.CategoryID = pro.CategoryID;
                check.BrandID = pro.BrandID;
                check.ProductName = pro.ProductName;
                check.Description = pro.Description;
                check.Price = pro.Price;
                check.ImageURL = pro.ImageURL;
                check.Quantity = pro.Quantity;
                check.CPU = pro.CPU;
                check.RAM   = pro.RAM;
                check.Storage = pro.Storage;
                check.GraphicsCard = pro.GraphicsCard;
                check.OperatingSystem = pro.OperatingSystem;
                check.Weight = pro.Weight;

                await _dbContext.SaveChangesAsync();
                return new { httpStatusCode = HttpStatusCode.OK, mess = "Sửa sản phẩm thành công !", data = check.ToProductDto() };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }
    }
}
