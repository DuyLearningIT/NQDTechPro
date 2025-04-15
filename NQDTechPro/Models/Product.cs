using System;
using System.Collections.Generic;

namespace NQDTechPro.Models;

public partial class Product
{
    public int ProductID { get; set; }

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

    public DateOnly? ReleaseDate { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
}
