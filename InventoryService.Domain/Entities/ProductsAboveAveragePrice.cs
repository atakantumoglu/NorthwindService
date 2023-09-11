using System;
using System.Collections.Generic;

namespace InventoryService.Domain.Entities;

public class ProductsAboveAveragePrice : BaseEntity
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
