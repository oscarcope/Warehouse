using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Order
{
    public int OrderId { get; set; }

    public string OrderNumber { get; set; } = null!;

    public DateOnly OrderDate { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
