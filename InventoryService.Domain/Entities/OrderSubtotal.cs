using System;
using System.Collections.Generic;

namespace InventoryService.Domain.Entities;

public class OrderSubtotal : BaseEntity
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
