using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Location
{
    public int LocationId { get; set; }

    public string LocationNumber { get; set; } = null!;

    public virtual ICollection<WarehouseBatch> WarehouseBatches { get; set; } = new List<WarehouseBatch>();
}
