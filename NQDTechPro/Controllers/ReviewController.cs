using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NQDTechPro.Data;
using NQDTechPro.DTOs.Review;
using NQDTechPro.Interfaces;
using NQDTechPro.Services;

namespace NQDTechPro.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly dbContext _dbcontext;
        private readonly IReviewService _reviewService;
        private readonly JwtService _jwtService;

        public ReviewController(dbContext dbcontext, IReviewService reviewService, JwtService jwtservice)
        {
            _dbcontext = dbcontext;
            _reviewService = reviewService;
            _jwtService = jwtservice;
        }
        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> CreateReviewAsync(CreateReview review)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized("Bạn cần đăng nhập để thực hiện !");
            }
            int.TryParse(_jwtService.GetUserIdFromToken(), out int userid);
            if (userid == 0)
                return BadRequest("Có lỗi xảy ra, vui lòng thử lại sau !");
            var result = await _reviewService.CreateReviewAsync(review, userid);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllReviewsAsync()
        {
            var result = await _reviewService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("get-byid")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var result = await _reviewService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-byproid")]
        public async Task<IActionResult> GetReviewByProductID(int proid)
        {
            var result = await _reviewService.GetByProductId(proid);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteReviewByID(int id)
        {
            var result = await _reviewService.DeleteReviewAsync(id);
            return Ok(result);
        }
    }
}
