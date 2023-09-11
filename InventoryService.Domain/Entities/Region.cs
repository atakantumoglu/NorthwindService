using System;
using System.Collections.Generic;

namespace InventoryService.Domain.Entities;

public class Region : BaseEntity
{
    public int RegionId { get; set; }

    public string RegionDescription { get; set; } = null!;

    public virtual ICollection<Territory> Territories { get; } = new List<Territory>();
}
