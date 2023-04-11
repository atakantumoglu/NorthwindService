//using InventoryService.Application.Services.Abstract;
//using InventoryService.Application.Services.Data.EFCore;
//using InventoryService.Domain.Entities;
//using InventoryService.Infrastructure.ContextDb;
//using Microsoft.EntityFrameworkCore;

//namespace InventoryService.Application.Services.Concrete
//{
//    public class ItemRepository : EFCoreRepository<Item>, IItemRepository
//    {
//        public ItemRepository(ApplicationDbContext context) : base(context)
//        {
//        }

//        public Task<Item> GetByCreatorIdAsync(int id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
