using NQDTechPro.DTOs.Review;

namespace NQDTechPro.Interfaces
{
    public interface IReviewService
    {
        Task<object> GetAllAsync();
        Task<object> GetByIdAsync(int reviewId);
        Task<object> CreateReviewAsync(CreateReview review, int userId);
        Task<object> DeleteReviewAsync(int reviewId);
        Task<object> GetByProductId(int productId);
    }
}
