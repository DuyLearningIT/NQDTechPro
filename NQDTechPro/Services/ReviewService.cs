using System.Net;
using Microsoft.EntityFrameworkCore;
using NQDTechPro.Data;
using NQDTechPro.DTOs.Review;
using NQDTechPro.Interfaces;
using NQDTechPro.Mappers;
using NQDTechPro.Models;

namespace NQDTechPro.Services
{
    public class ReviewService : IReviewService
    {
        private readonly dbContext _dbcontext;
       
        public ReviewService(dbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<object> CreateReviewAsync(CreateReview review, int userId)
        {
            try
            {
                review.UserID = userId;

                await _dbcontext.Reviews.AddAsync(review.FromCreateToReview());
                await _dbcontext.SaveChangesAsync();
                return new { httpStatusCode = HttpStatusCode.Created, data = review, mess = "Tạo đánh giá thành công !" };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> DeleteReviewAsync(int reviewId)
        {
            try
            {
                var review = await _dbcontext.Reviews.FindAsync(reviewId);
                if (review == null)
                    return new { httpStatusCode = HttpStatusCode.NotFound, mess = "Không tìm thấy đánh giá !" };
                _dbcontext.Reviews.Remove(review);
                await _dbcontext.SaveChangesAsync();
                return new { httpStatusCode = HttpStatusCode.NoContent, mess = "Xóa thành công đánh giá !", data = review.ToReviewDto() };
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
                var reviews = await _dbcontext.Reviews.ToListAsync();
                var data = reviews.Select(_ => _.ToReviewDto());
                return new { httpStatusCode = HttpStatusCode.OK, mess = "Lấy thành công đánh giá !", data = data };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> GetByIdAsync(int reviewId)
        {
            try
            {
                var review = await _dbcontext.Reviews.FindAsync(reviewId);
                if (review == null)
                    return new { httpStatusCode = HttpStatusCode.NotFound, mess = "Không tìm thấy đánh giá !" };
                return new { httpStatusCode = HttpStatusCode.OK, mess = "Lấy thành công đánh giá !", data = review.ToReviewDto() };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }

        public async Task<object> GetByProductId(int productId)
        {
            try
            {
                var reviews = await _dbcontext.Reviews
                    .Where(_ => _.ProductID == productId)
                    .ToListAsync();
                var data = reviews.Select(_ => _.ToReviewDto());
                return new { httpStatusCode = HttpStatusCode.OK, mess = "Lấy thành công đánh giá !", data = data };
            }
            catch (Exception ex)
            {
                return new { httpStatusCode = HttpStatusCode.InternalServerError, mess = ex.Message };
            }
        }
    }
}
