using System;
using System.Collections.Generic;

namespace TaskTjdeed.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public decimal? TotalPrice { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual User? User { get; set; }
}
