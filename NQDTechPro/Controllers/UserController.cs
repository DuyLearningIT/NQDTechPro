using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NQDTechPro.Data;
using NQDTechPro.DTOs.User;
using NQDTechPro.Interfaces;

namespace NQDTechPro.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly dbContext _dbcontext;
        private readonly IUserServices _userServices;
        public UserController(dbContext dbcontext, IUserServices usersServices)
        {
            _dbcontext  = dbcontext;
            _userServices = usersServices;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userServices.GetAllAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("get-byid")]
        public async Task<IActionResult> GetuserByID(int userId)
        {
            var result = await _userServices.GetByIdAsync(userId);
            return Ok(result);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUser user)
        {
            var result = await _userServices.CreateUserAsync(user);
            return Ok(result);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUser user)
        {
            var result = await _userServices.LoginAsync(user);
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUserAsync(UpdateUser user)
        {
            var result = await _userServices.UpdateUserAsync(user);
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteUserAsync(int userId)
        {
            var result = await _userServices.DeleteUserAsync(userId);
            return Ok(result);
        }
    }
}
