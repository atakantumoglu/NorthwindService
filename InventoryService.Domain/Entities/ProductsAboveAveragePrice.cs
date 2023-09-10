using System;
using System.Collections.Generic;

namespace InventoryService.Domain.Entities;

public partial class ProductsAboveAveragePrice : BaseEntity
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
