using System;
using System.Collections.Generic;

namespace InventoryService.Domain.Entities;

public class CustomerAndSuppliersByCity : BaseEntity
{
    public string? City { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string Relationship { get; set; } = null!;
}
