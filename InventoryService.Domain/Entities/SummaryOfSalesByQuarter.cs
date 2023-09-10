using System;
using System.Collections.Generic;

namespace InventoryService.Domain.Entities;

public partial class SummaryOfSalesByQuarter : BaseEntity
{
    public DateTime? ShippedDate { get; set; }

    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
