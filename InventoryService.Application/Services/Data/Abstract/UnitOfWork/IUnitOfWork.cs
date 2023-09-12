using NorthwindService.Application.Services.Data.Abstract.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace NorthwindService.Application.Services.Data.Abstract
{
    public interface IUnitOfWork<TContext> : IUnitOfWork, IDisposable where TContext : DbContext
    {
        TContext Context { get; }
    }
}
