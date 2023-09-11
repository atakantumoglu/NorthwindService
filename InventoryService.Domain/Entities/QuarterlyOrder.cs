using System;
using System.Collections.Generic;

namespace InventoryService.Domain.Entities;

public class QuarterlyOrder : BaseEntity
{
    public string? CustomerId { get; set; }

    public string? CompanyName { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }
}
