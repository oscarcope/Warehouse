using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int BatchId { get; set; }

    public int Quantity { get; set; }

    public virtual Batch Batch { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<OrderItemLocation> OrderItemLocations { get; set; } = new List<OrderItemLocation>();

    [NotMapped]
    public Product Product => Batch.ManufacturingLot.Product;
}
