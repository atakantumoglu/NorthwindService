﻿using System;
using System.Collections.Generic;

namespace InventoryService.Domain.Entities;

public partial class Territory : BaseEntity
{
    public string TerritoryId { get; set; } = null!;

    public string TerritoryDescription { get; set; } = null!;

    public int RegionId { get; set; }

    public virtual Region Region { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
