using NQDTechPro.DTOs.Review;
using NQDTechPro.Models;

namespace NQDTechPro.Mappers
{
    public static class ReviewMapperr
    {
        public static Review ToReview(this ReviewDto review)
        {
            return new Review
            {
                ReviewID = review.ReviewID,
                ProductID = review.ProductID,
                UserID = review.UserID,
                Comment = review.Comment,
                Rating = review.Rating,
                CreatedAt = review.CreatedAt,
            };
        }

        public static ReviewDto ToReviewDto(this Review review)
        {
            return new ReviewDto
            {
                ReviewID = review.ReviewID,
                ProductID = review.ProductID,
                UserID = review.UserID,
                Comment = review.Comment,
                Rating = review.Rating,
                CreatedAt = review.CreatedAt,
            };
        }
        public static Review FromCreateToReview(this CreateReview review)
        {
            return new Review
            {
                ProductID = review.ProductID,
                UserID = review.UserID,
                Comment = review.Comment,
                Rating = review.Rating,
            };
        }
    }
}
