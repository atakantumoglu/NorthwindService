using InventoryService.Application.Services.Data.Abstract;
using InventoryService.Application.Services.Data.Abstract.UnitOfWork;
using InventoryService.Application.Services.Data.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Application.Services.Data.Abstract
{
    public interface IUnitOfWork<TContext> : IUnitOfWork, IDisposable where TContext : DbContext
    {
        TContext Context { get; }
    }
}
