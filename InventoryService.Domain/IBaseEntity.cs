using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Domain
{
    public interface IBaseEntity
    {
        public bool IsDeleted { get; set; }
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid LastModifierId { get; set; }
        public DateTime LastModificationTime { get; set; }

    }
}
