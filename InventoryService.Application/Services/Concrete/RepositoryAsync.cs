using NorthwindService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using NorthwindService.Application.Services.Helpers;
using NorthwindService.Application.Services.Abstract;
using NorthwindService.Application.Services.Concrete.Paging;

namespace NorthwindService.Application.Services.Concrete
{
    public class RepositoryAsync<T>(DbContext dbContext, IHttpContextAccessor httpContextAccessor)
        : IRepositoryAsync<T>
        where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet = dbContext.Set<T>();

        public virtual async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool enableTracking = true, bool ignoreQueryFilters = false)
        {
            IQueryable<T> query = _dbSet;
            if (!enableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return await orderBy(query).FirstOrDefaultAsync();
            }

            return await query.FirstOrDefaultAsync();
        }

        public Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int pageNumber = 0, int size = 20, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = _dbSet;
            if (!enableTracking)
            {
                queryable = queryable.AsNoTracking();
            }

            if (include != null)
            {
                queryable = include(queryable);
            }

            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }

            if (size == 0)
            {
                size = 20;
            }

            if (orderBy != null)
            {
                return orderBy(queryable).ToPaginateAsync(pageNumber, size, 0, cancellationToken);
            }

            return queryable.ToPaginateAsync(pageNumber, size, 0, cancellationToken);
        }

        public Task<IPaginate<TResult>> GetListAsync<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int pageNumber = 0, int size = 20, bool enableTracking = true, CancellationToken cancellationToken = default, bool ignoreQueryFilters = false) where TResult : class
        {
            IQueryable<T> queryable = _dbSet;
            if (!enableTracking)
            {
                queryable = queryable.AsNoTracking();
            }

            if (include != null)
            {
                queryable = include(queryable);
            }

            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                queryable = queryable.IgnoreQueryFilters();
            }

            if (size == 0)
            {
                size = 20;
            }

            if (orderBy != null)
            {
                return orderBy(queryable).Select(selector).ToPaginateAsync(pageNumber, size, 0, cancellationToken);
            }

            return queryable.Select(selector).ToPaginateAsync(pageNumber, size, 0, cancellationToken);
        }

        public virtual ValueTask<EntityEntry<T>> InsertAsync(T entity, CancellationToken cancellationToken = default)
        {
            Guid creatorId = httpContextAccessor.HttpContext!.User.Id();
            entity.CreationTime = DateTime.Now;
            entity.CreatorId = creatorId;
            return _dbSet.AddAsync(entity, cancellationToken);
        }

        public virtual Task InsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            foreach (T entity in entities)
            {
                entity.CreatorId = httpContextAccessor.HttpContext!.User.Id();
                entity.CreationTime = DateTime.Now;
            }

            return _dbSet.AddRangeAsync(entities, cancellationToken);
        }
    }
}
