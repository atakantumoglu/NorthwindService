using InventoryService.Application.Services.Data.Abstract;
using InventoryService.Application.Services.Data.Concrete.Paging;
using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace InventoryService.Application.Services.Data.Concrete
{
    public abstract class BaseRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        protected readonly DbContext DbContext;

        protected readonly DbSet<T> DbSet;

        protected BaseRepository(DbContext context)
        {
            DbContext = context ?? throw new ArgumentException("context");
            DbSet = DbContext.Set<T>();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool enableTracking = true)
        {
            IQueryable<T> queryable = DbSet;
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

            if (orderBy != null)
            {
                return orderBy(queryable).FirstOrDefault();
            }

            return queryable.FirstOrDefault();
        }

        public IPaginate<T> GetList(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int pageNumber = 0, int size = 20, bool enableTracking = true)
        {
            IQueryable<T> queryable = DbSet;
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

            return (orderBy != null) ? orderBy(queryable).ToPaginate(pageNumber, size) : queryable.ToPaginate(pageNumber, size);
        }

        public IPaginate<TResult> GetList<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int pageNumber = 0, int size = 20, bool enableTracking = true) where TResult : class
        {
            IQueryable<T> queryable = DbSet;
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

            return (orderBy != null) ? orderBy(queryable).Select(selector).ToPaginate(pageNumber, size) : queryable.Select(selector).ToPaginate(pageNumber, size);
        }
    }
}
