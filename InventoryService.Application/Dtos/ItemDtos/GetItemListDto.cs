namespace InventoryService.Application.Dtos.ItemDtos
{
    public class GetItemListDto
    {
        public List<ItemResponseDto> Data { get; set; }
        public int totalRecords { get; set; }
        public int totalPages { get; set; }
    }
}
