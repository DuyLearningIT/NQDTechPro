using System.Net;
using Microsoft.EntityFrameworkCore;
using NQDTechPro.Data;
using NQDTechPro.DTOs.User;
using NQDTechPro.Interfaces;
using NQDTechPro.Mappers;

namespace NQDTechPro.Services
{
    public class UserService :IUserServices
    {
        private readonly dbContext _dbcontext;
        private readonly JwtService _jwtService;
        public UserService(dbContext dbcontext, JwtService jwtService)
        {
            _dbcontext = dbcontext;
            _jwtService = jwtService;
        }

        public async Task<object> CreateUserAsync(CreateUser user)
        {
            try
            {
                var check = await _dbcontext.Users.FirstOrDefaultAsync(_ => _.Email == user.Email);
                if (check != null)
                    return new { httpStatusCode = HttpStatusCode.BadRequest, mess = "Email đã tồn tại !" };
                await _dbcontext.Users.AddAsync(user.FromCreateToUser());
                await _dbcontext.SaveChangesAsync();
                var data = user.FromCreateToUser().ToUserDto();
                return new { httpStatusCode = HttpStatusCode.Created, mess = "Tạo tài khoản thành công !", data = data };

            }catch(Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> DeleteUserAsync(int UserId)
        {
            try
            {
                var check = await _dbcontext.Users
                    .Include(_ => _.Orders)
                    .Include(_ => _.Reviews)
                    .FirstOrDefaultAsync(_ => _.UserID == UserId);

                if (check == null)
                    return new { httpStatusCode = HttpStatusCode.NotFound, mess = "Không tìm thấy người dùng !" };
                _dbcontext.Orders.RemoveRange(check.Orders);
                _dbcontext.Reviews.RemoveRange(check.Reviews);
                _dbcontext.Users.Remove(check);
                await _dbcontext.SaveChangesAsync();

                return new { httpStatusCode = HttpStatusCode.NoContent, mess = "Xóa thành công người dùng !" };
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
                var users = await _dbcontext.Users.ToListAsync();
                var data = users.Select(_ => _.ToUserDto());
                return new {httpStatusCode = HttpStatusCode.OK, data = data, mess = "Lấy thành công tất cả người dùng !" };

            }catch(Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> GetByIdAsync(int UserId)
        {
            try
            {
                var check = await _dbcontext.Users.FindAsync(UserId);
                if (check == null)
                    return new { httpStatusCode = HttpStatusCode.NotFound, mess = "Không tìm thấy người dùng !" };
                
                return new { httpStatusCode = HttpStatusCode.OK, data = check.ToUserDto(), mess = "Lấy thành công người dùng !" };

            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> LoginAsync(LoginUser user)
        {
            try
            {
                var check = await _dbcontext.Users.FirstOrDefaultAsync(_ => _.Email == user.Email);
                if (check == null)
                    return new { httpStatusCode = HttpStatusCode.NotFound, mess = "Email này chưa đăng ký sử dụng !" };
                if(!BCrypt.Net.BCrypt.Verify(user.Password, check.Password))
                    return new { httpStatusCode = HttpStatusCode.BadRequest, mess = "Thông tin tài khoản hoặc mật khẩu không chính xác !" };

                var data = new
                {
                    user = check.ToUserDto(),
                    token = _jwtService.GenerateJwtToken(check)
                };
                return new
                {
                    httpStatusCode = HttpStatusCode.OK,
                    mes = "Đăng nhập thành công !",
                    data = data
                };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> UpdateUserAsync(UpdateUser user)
        {
            try
            {
                var check = await _dbcontext.Users.FirstOrDefaultAsync(_ => _.Email == user.Email);
                if (check == null)
                    return new { httpStatusCode = HttpStatusCode.NotFound, mess = "Không tìm thấy người dùng !" };
                check.Username = user.Username;
                check.FullName = user.FullName;
                check.Address = user.Address;
                check.PhoneNumber = user.PhoneNumber;
                await _dbcontext.SaveChangesAsync();
                return new { httpStatusCode = HttpStatusCode.OK, mess = "Cập nhật người dùng thành công !", data = check.ToUserDto() };
            }catch(Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }
    }
}
