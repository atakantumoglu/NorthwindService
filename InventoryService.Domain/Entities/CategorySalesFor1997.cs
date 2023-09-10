using System;
using System.Collections.Generic;

namespace InventoryService.Domain.Entities;

public partial class CategorySalesFor1997 : BaseEntity
{
    public string CategoryName { get; set; } = null!;

    public decimal? CategorySales { get; set; }
}
