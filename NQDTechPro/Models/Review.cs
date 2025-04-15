﻿using System;
using System.Collections.Generic;

namespace NQDTechPro.Models;

public partial class Review
{
    public int ReviewID { get; set; }

    public int ProductID { get; set; }

    public int UserID { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
