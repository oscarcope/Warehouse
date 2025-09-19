using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class ManufacturingLot
{
    public int ManufacturingLotId { get; set; }

    public string LotNumber { get; set; } = null!;

    public int ProductId { get; set; }

    public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();

    public virtual Product Product { get; set; } = null!;
}
