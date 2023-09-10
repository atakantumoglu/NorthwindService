using System;
using System.Collections.Generic;

namespace InventoryService.Domain.Entities;

public partial class CustomerDemographic : BaseEntity
{
    public string CustomerTypeId { get; set; } = null!;

    public string? CustomerDesc { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}
