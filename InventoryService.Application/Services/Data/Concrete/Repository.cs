using NorthwindService.Application.Services.Data.Helper;
using NorthwindService.Application.Services.Data.Abstract;
using NorthwindService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace NorthwindService.Application.Services.Data.Concrete
{
    public class Repository<T> : BaseRepository<T>, IRepository<T>, IReadRepository<T>, IDisposable where T : BaseEntity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Repository(DbContext context, IHttpContextAccessor httpContextAccessor)
            : base(context)
        {
            _httpContextAccessor = httpContextAccessor ?? null;
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool enableTracking = true, bool ignoreQueryFilters = false)
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

            if (ignoreQueryFilters)
            {
                queryable = queryable.IgnoreQueryFilters();
            }

            return (orderBy != null) ? orderBy(queryable).FirstOrDefault() : queryable.FirstOrDefault();
        }

        public void Dispose()
        {
            DbContext?.Dispose();
        }

        public virtual T Insert(T entity)
        {
            entity.CreatorId = _httpContextAccessor.HttpContext!.User.Id();
            entity.CreationTime = DateTime.Now;
            return DbSet.Add(entity).Entity;
        }

        public void Insert(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                entity.CreatorId = _httpContextAccessor.HttpContext!.User.Id();
                entity.CreationTime = DateTime.Now;
            }

            DbSet.AddRange(entities);
        }

        public T InsertIfNotExists(Expression<Func<T, bool>> predicate, T entity)
        {
            entity.CreatorId = _httpContextAccessor.HttpContext!.User.Id();
            if (DbSet.Any(predicate))
            {
                return DbSet.SingleOrDefault(predicate.Compile());
            }

            DbSet.Add(entity);
            return entity;
        }

        public void Update(T entity)
        {
            entity.CreationTime = entity.CreationTime;
            entity.CreatorId = entity.CreatorId;
            entity.LastModifierId = _httpContextAccessor.HttpContext!.User.Id();
            entity.LastModificationTime = DateTime.Now;
            DbSet.Update(entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                entity.CreationTime = entity.CreationTime;
                entity.CreatorId = entity.CreatorId;
                entity.LastModifierId = _httpContextAccessor.HttpContext!.User.Id();
                entity.LastModificationTime = DateTime.Now;
            }

            DbSet.UpdateRange(entities);
        }
    }
}
