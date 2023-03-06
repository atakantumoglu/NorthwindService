using InventoryService.Application.Services.Abstract;

namespace InventoryService.Application.Services.Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepository ItemRepository { get; }
        IPersonelRepository PersonelRepository { get; }
        int Save();
        Task<int> SaveAsync();
    }
}
