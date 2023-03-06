using InventoryService.Application.Services.Abstract;
using InventoryService.Application.Services.Concrete;
using InventoryService.Application.Services.Data.Abstract;
using InventoryService.Infrastructure.ContextDb;

namespace InventoryService.Application.Services.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IItemRepository ItemRepository { get; set; }
        public IPersonelRepository PersonelRepository { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ItemRepository = new ItemRepository(context);
            PersonelRepository= new PersonelRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }


}
