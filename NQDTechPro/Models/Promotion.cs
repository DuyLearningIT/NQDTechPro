using System;
using System.Collections.Generic;

namespace NQDTechPro.Models;

public partial class Promotion
{
    public int PromotionID { get; set; }

    public string PromotionName { get; set; } = null!;

    public decimal? DiscountPercentage { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
