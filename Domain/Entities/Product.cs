using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int SupplierId { get; set; }

    public virtual ICollection<ManufacturingLot> ManufacturingLots { get; set; } = new List<ManufacturingLot>();

    public virtual ICollection<OrderItemLocation> OrderItemLocations { get; set; } = new List<OrderItemLocation>();

    public virtual Supplier Supplier { get; set; } = null!;
}
