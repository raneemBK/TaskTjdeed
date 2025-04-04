﻿using System;
using System.Collections.Generic;

namespace TaskTjdeed.Models;

public partial class OrderProduct
{
    public int OrderProductId { get; set; }

    public int? Quantities { get; set; }

    public int? ProductId { get; set; }

    public int? OrderId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
