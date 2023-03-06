using InventoryService.Domain;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace InventoryService.Application.Services.Data.EFCore
{
    //Generic Repo
    public class EFCoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IBaseEntity
        where TContext : DbContext
    {
        private readonly TContext _context;

        public EFCoreRepository(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public async Task<TEntity> DeleteAsync(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(entity);
            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync(bool isDeleted, int page = 1, int size = 10)
        {

            return await _context.Set<TEntity>()
                .Where(x => x.IsDeleted.Equals(isDeleted))
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return entity;
        }
    }
}
