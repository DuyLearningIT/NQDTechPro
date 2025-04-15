using System;
using System.Collections.Generic;

namespace NQDTechPro.Models;

public partial class OrderDetail
{
    public int OrderDetailID { get; set; }

    public int OrderID { get; set; }

    public int ProductID { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Subtotal { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
