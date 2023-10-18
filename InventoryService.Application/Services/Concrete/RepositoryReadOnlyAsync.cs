using NorthwindService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using NorthwindService.Application.Services.Abstract;

namespace NorthwindService.Application.Services.Concrete
{
    public class RepositoryReadOnlyAsync<T> : RepositoryAsync<T>, IRepositoryReadOnlyAsync<T> where T : BaseEntity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RepositoryReadOnlyAsync(DbContext context, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? null;
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await base.SingleOrDefaultAsync(predicate, orderBy, include, enableTracking: false);
        }

        public async Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int pageNumber = 0,
            int size = 20)
        {
            if (size == 0)
            {
                size = 20;
            }

            return await GetListAsync(predicate, orderBy, include, pageNumber, size, enableTracking: false);
        }

        public async Task<IPaginate<TResult>> GetListAsync<TResult>(Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int pageNumber = 0,
            int size = 20,
            CancellationToken cancellationToken = default,
            bool ignoreQueryFilters = false)
            where TResult : class
        {
            if (size == 0)
            {
                size = 20;
            }

            return await GetListAsync(selector, predicate, orderBy, include, pageNumber, size, enableTracking: false, cancellationToken, ignoreQueryFilters);
        }
    }
}
