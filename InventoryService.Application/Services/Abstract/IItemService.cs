using InventoryService.Application.Dtos.ItemDtos;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.Services.Abstract
{
    public interface IItemService
    {
        Task<ItemResponseDto> ItemCreate(ItemCreateDto itemDto);
        Task<Item> ItemUpdate(ItemUpdateDto itemDto);
        Task<Item> ItemDelete(ItemDeleteDto itemDto);
        Task<GetItemListDto> GetItemList(bool isDeleted, int page = 1, int pageSize = 10);
        Task<ItemResponseDto> GetItemById(Guid id);
    }
}
