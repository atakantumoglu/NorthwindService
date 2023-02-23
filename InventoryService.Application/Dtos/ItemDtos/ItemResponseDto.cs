using InventoryService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Application.Dtos.ItemDtos
{
    public class ItemResponseDto
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public Guid ItemTypeId { get; set; }
    }
}
