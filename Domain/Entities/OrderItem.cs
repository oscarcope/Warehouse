using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int BatchId { get; set; }

    public int Quantity { get; set; }

    public virtual Batch Batch { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<OrderItemLocation> OrderItemLocations { get; set; } = new List<OrderItemLocation>();
}
