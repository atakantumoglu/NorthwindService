using InventoryService.Application.Dtos.ItemDtos;
using InventoryService.Application.Services.Data;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.Services.Abstract
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<Item> GetByCreatorIdAsync(int id);
    }
}
