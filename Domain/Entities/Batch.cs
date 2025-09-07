using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Batch
{
    public int BatchId { get; set; }

    public string BatchNumber { get; set; } = null!;

    public int ManufacturingLotId { get; set; }

    public int Quantity { get; set; }

    public virtual ManufacturingLot ManufacturingLot { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<WarehouseBatch> WarehouseBatches { get; set; } = new List<WarehouseBatch>();
}
