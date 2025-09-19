using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class OrderItemLocation
{
    public int OrderItemLocationId { get; set; }

    public int OrderItemId { get; set; }

    public int WarehouseBatchId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual OrderItem OrderItem { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual WarehouseBatch WarehouseBatch { get; set; } = null!;
}
