using System.Net;
using Microsoft.EntityFrameworkCore;
using NQDTechPro.Data;
using NQDTechPro.DTOs.Brand;
using NQDTechPro.Interfaces;
using NQDTechPro.Mappers;
using NQDTechPro.Models;

namespace NQDTechPro.Services
{
    public class BrandService : IBrandServices
    {
        private readonly dbContext _dbContext;
        public BrandService(dbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<object> CreateBrandAsync(CreateBrand brand)
        {
            try
            {
                var check = await _dbContext.Brands.FirstOrDefaultAsync(_ => _.BrandName == brand.BrandName);
                if (check != null)
                    return new { httpStatusCode = HttpStatusCode.BadRequest, mess = "Đã tồn tại hãng này !" };

                await _dbContext.Brands.AddAsync(brand.FromCreateBrandToBrand());
                await _dbContext.SaveChangesAsync();
                return new { httpStatusCode = HttpStatusCode.Created, mess = "Tạo thành công hãng!", data = brand};
            }catch(Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> DeleteBrandAsync(int brandId)
        {
            try
            {
                var check = await _dbContext.Brands.FindAsync(brandId);
                if (check == null)
                    return new { httpStatusCode = HttpStatusCode.NotFound, mess = "Không tìm thấy hãng !" };
                _dbContext.Remove(check);
                await _dbContext.SaveChangesAsync();
                return new { httpStatusCode = HttpStatusCode.NoContent, mess = "Xóa thành công hãng !" };
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
                var brands = await _dbContext.Brands.ToListAsync();
                var data = brands.Select(_ => _.ToBrandDto());
                return new { httpStatusCode = HttpStatusCode.OK, mess = "Lấy thành công hãng !", data = data };
            }
            catch (Exception ex) {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> GetByIdAsync(int brandId)
        {
            try
            {
                var check = await _dbContext.Brands.FindAsync(brandId);
                if (check == null)
                    return new { httpStatusCode = HttpStatusCode.NotFound, mess = "Không tìm thấy hãng !" };
                return new { httpStatusCode = HttpStatusCode.OK, mess = "Lấy thành công hãng !", data = check.ToBrandDto() };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> UpdateBrand(BrandDto brand)
        {
            try
            {
                var check = await _dbContext.Brands.FirstOrDefaultAsync(_ => _.BrandID == brand.BrandID); 
                if (check == null)
                    return new { httpStatusCode = HttpStatusCode.NotFound, mess = "Không tìm thấy hãng !" };

                check.BrandName = brand.BrandName;
                await _dbContext.SaveChangesAsync();

                return new { httpStatusCode = HttpStatusCode.OK, mess = "Sửa thành công hãng !", data = check.ToBrandDto() };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }
    }
}
