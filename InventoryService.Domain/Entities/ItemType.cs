using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Domain.Entities
{
    public class ItemType : BaseEntity
    {

        public string Name { get; set; }
        public List <Item> Items { get; set; }

    }
}
