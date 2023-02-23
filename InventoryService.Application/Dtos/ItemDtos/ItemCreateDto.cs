using InventoryService.Domain.Enums;


namespace InventoryService.Application.Dtos.ItemDtos
{
    public class ItemCreateDto
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public Guid ItemTypeId { get; set; }
    }
}
