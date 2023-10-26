using NorthwindService.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace NorthwindService.Application.Services.Abstract
{
    public interface IRepositoryAsync<T> where T : BaseEntity
    {
        Task<T> SingleOrDefaultAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enableTracking = true,
            bool ignoreQueryFilters = false);

        Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int pageNumber = 0, int size = 20,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);

        ValueTask<EntityEntry<T>> InsertAsync(T entity, CancellationToken cancellationToken = default);
        Task InsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    }

}