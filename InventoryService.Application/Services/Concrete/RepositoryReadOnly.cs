using NorthwindService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using NorthwindService.Application.Services.Abstract;

namespace NorthwindService.Application.Services.Concrete
{
    public class RepositoryReadOnly<T> : BaseRepository<T>, IRepositoryReadOnly<T> where T : BaseEntity
    {
        public RepositoryReadOnly(DbContext context)
            : base(context)
        {
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return SingleOrDefault(predicate, orderBy, include, enableTracking: false);
        }

        public IPaginate<T> GetList(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int pageNumber = 0,
            int size = 20)
        {
            return GetList(predicate, orderBy, include, pageNumber, size, enableTracking: false);
        }

        public IPaginate<TResult> GetList<TResult>(Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int pageNumber = 0,
            int size = 20)
            where TResult : class
        {
            return GetList(selector, predicate, orderBy, include, pageNumber, size, enableTracking: false);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return FirstOrDefault(predicate, orderBy, include);
        }
    }
}
