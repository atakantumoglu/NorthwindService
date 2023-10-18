using Microsoft.EntityFrameworkCore;
using NorthwindService.Application.Services.Abstract;

namespace NorthwindService.Application.Services.Abstract.UnitOfWork
{
    public interface IUnitOfWork<TContext> : IUnitOfWork, IDisposable where TContext : DbContext
    {
        TContext Context { get; }
    }
}
