namespace InventoryService.Application.Dtos.ItemDtos
{
    public class ItemResponseDto
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public Guid ItemTypeId { get; set; }
    }
}
