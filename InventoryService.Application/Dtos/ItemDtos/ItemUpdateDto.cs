namespace InventoryService.Application.Dtos.ItemDtos
{
    public class ItemUpdateDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public Guid ItemTypeId { get; set; }
    }

}
