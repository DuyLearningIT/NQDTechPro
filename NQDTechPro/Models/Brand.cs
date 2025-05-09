﻿using System;
using System.Collections.Generic;

namespace NQDTechPro.Models;

public partial class Brand
{
    public int BrandID { get; set; }

    public string BrandName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
