using InventoryService.Application.Services.Data.Abstract.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Application.Services.Data.Abstract
{
    public interface IUnitOfWork<TContext> : IUnitOfWork, IDisposable where TContext : DbContext
    {
        TContext Context { get; }
    }
}
