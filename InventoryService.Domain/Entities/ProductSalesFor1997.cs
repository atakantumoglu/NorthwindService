using System;
using System.Collections.Generic;

namespace InventoryService.Domain.Entities;

public class ProductSalesFor1997 : BaseEntity
{
    public string CategoryName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal? ProductSales { get; set; }
}
