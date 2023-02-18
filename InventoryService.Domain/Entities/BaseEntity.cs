using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid LastModifierId { get; set; }
        public DateTime LastModificationTime { get; set; }
        public bool IsDeleted { get; set; }

    }
}
