namespace InventoryService.Domain.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public Guid ItemTypeId { get; set; }
    }
}
