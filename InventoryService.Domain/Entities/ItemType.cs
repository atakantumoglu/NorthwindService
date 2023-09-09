namespace InventoryService.Domain.Entities
{
    public class ItemType : BaseEntity
    {
        public string Name { get; set; }
        public List <Item> Items { get; set; }
    }
}
