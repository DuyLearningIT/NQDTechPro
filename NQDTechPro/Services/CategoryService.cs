using System.Net;
using Microsoft.EntityFrameworkCore;
using NQDTechPro.Data;
using NQDTechPro.DTOs.Category;
using NQDTechPro.Interfaces;
using NQDTechPro.Mappers;

namespace NQDTechPro.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly dbContext _dbContext;
        public CategoryService(dbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<object> CreateCategoryAsync(CreateCategory cat)
        {
            try
            {
                var check = await _dbContext.Categories.FirstOrDefaultAsync(_ => _.CategoryName ==  cat.CategoryName);
                if (check != null)
                    return new { httpStatusCode = HttpStatusCode.BadRequest, mess = "Đã tồn tại thể loại !" };
                await _dbContext.AddAsync(cat.FromCreateCategoryToCategory());
                await _dbContext.SaveChangesAsync();
                return new { httpStatusCode = HttpStatusCode.Created, mess = "Tạo thể loại thành công !", data = cat };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> DeleteCategoryAsync(int id)
        {
            try
            {
                var cat = await _dbContext.Categories.FindAsync(id);
                if (cat == null)
                    return new { httpStatuscode = HttpStatusCode.NotFound, mess = "Không tìm thấy thể loại !" };
                _dbContext.Categories.Remove(cat);
                await _dbContext.SaveChangesAsync();
                return new { httpStatusCode = HttpStatusCode.NoContent, mess = "Xóa thành công !" };
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
                var cats = await _dbContext.Categories.ToListAsync();
                var data = cats.Select(_ => _.ToCategoryDto());
                return new { httpStatusCode = HttpStatusCode.OK, mess = "Lấy sản phẩm thành công !", data = data };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> GetByIdAsync(int id)
        {
            try
            {
                var cat = await _dbContext.Categories.FindAsync(id);
                if (cat == null)
                    return new { httpStatuscode = HttpStatusCode.NotFound, mess = "Không tìm thấy thể loại !" };

                return new { httpStatusCode = HttpStatusCode.OK, mess = "Tìm thể loại thành công !", data = cat.ToCategoryDto() };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> UpdateCategoryAsync(CategoryDto cat)
        {
            try
            {
                var check = await _dbContext.Categories.FirstOrDefaultAsync(_ => _.CategoryID == cat.CategoryID);
                if (check == null)
                    return new { httpStatuscode = HttpStatusCode.NotFound, mess = "Không tìm thấy thể loại !" };

                check.CategoryName = cat.CategoryName;
                await _dbContext.SaveChangesAsync();
                return new { httpStatusCode = HttpStatusCode.OK, mess = "Cập nhật thành công !", data = check.ToCategoryDto() };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }
    }
}
