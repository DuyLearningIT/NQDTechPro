using System;
using System.Collections.Generic;

namespace NQDTechPro.Models;

public partial class Order
{
    public int OrderID { get; set; }

    public int UserID { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? ShippingAddress { get; set; }

    public string? OrderStatus { get; set; }

    public decimal TotalAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public string? TransactionID { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual User User { get; set; } = null!;
}
