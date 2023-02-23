using InventoryService.Domain.Entities;
using InventoryService.Domain.Enums;


namespace InventoryService.Application.Dtos.ItemDtos
{
    public class ItemUpdateDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }
        public Guid ItemTypeId { get; set; }
    }

}
