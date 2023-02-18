using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Domain.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public Guid ItemTypeId { get; set; }


    }
}
