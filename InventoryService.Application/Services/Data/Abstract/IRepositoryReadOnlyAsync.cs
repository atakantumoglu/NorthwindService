using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Application.Services.Data.Abstract
{
    public interface IRepositoryReadOnlyAsync<T> where T : BaseEntity
    {
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>> predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, 
            int pageNumber = 0, 
            int size = 20);

        Task<IPaginate<TResult>> GetListAsync<TResult>(Expression<Func<T, TResult>> selector, 
            Expression<Func<T, bool>> predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, 
            int pageNumber = 0, 
            int size = 20, 
            CancellationToken cancellationToken = default(CancellationToken), 
            bool ignoreQueryFilters = false) 
            where TResult : class;
    }
}