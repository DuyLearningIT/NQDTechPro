namespace NQDTechPro.DTOs.Review
{
    public class CreateReview
    {
        public int ProductID { get; set; }

        public int UserID { get; set; }

        public int Rating { get; set; }

        public string? Comment { get; set; }

    }
}
