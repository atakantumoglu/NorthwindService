using System;
using System.Collections.Generic;

namespace InventoryService.Domain.Entities;

public class SalesTotalsByAmount : BaseEntity
{
    public decimal? SaleAmount { get; set; }

    public int OrderId { get; set; }

    public string CompanyName { get; set; } = null!;

    public DateTime? ShippedDate { get; set; }
}
