namespace NQDTechPro.DTOs.Product
{
    public class CreateProduct
    {
        public int CategoryID { get; set; }

        public int BrandID { get; set; }

        public string ProductName { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? ImageURL { get; set; }

        public int Quantity { get; set; }

        public string? CPU { get; set; }

        public string? RAM { get; set; }

        public string? Storage { get; set; }

        public string? Screen { get; set; }

        public string? GraphicsCard { get; set; }

        public string? OperatingSystem { get; set; }

        public string? Weight { get; set; }
    }
}
