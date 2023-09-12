using NorthwindService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace NorthwindService.Application.Services.Data.Abstract
{
    public interface IReadRepository<T> where T : BaseEntity
    {
        T SingleOrDefault(
            Expression<Func<T, bool>> predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            Func<IQueryable<T>, 
                IIncludableQueryable<T, object>> include = null, 
            bool enableTracking = true);
       
        IPaginate<T> GetList(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int index = 0, int size = 20,
            bool enableTracking = true);

        IPaginate<TResult> GetList<TResult>(
            Expression<Func<T, TResult>> selector, 
            Expression<Func<T, bool>> predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, 
            int index = 0, 
            int size = 20, 
            bool enableTracking = true) 
            where TResult : class;
    }
}
