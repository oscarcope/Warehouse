using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class WarehouseBatch
{
    public int WarehouseBatchId { get; set; }

    public int BatchId { get; set; }

    public int LocationId { get; set; }

    public int Quantity { get; set; }

    public virtual Batch Batch { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<OrderItemLocation> OrderItemLocations { get; set; } = new List<OrderItemLocation>();
}
