using InventoryService.Application.Services.Data.Abstract;
using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Application.Services.Data.Concrete
{
    public class RepositoryReadOnly<T> : BaseRepository<T>, IRepositoryReadOnly<T> where T : BaseEntity
    {
        public RepositoryReadOnly(DbContext context)
            : base(context)
        {
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return SingleOrDefault(predicate, orderBy, include, enableTracking: false);
        }

        public IPaginate<T> GetList(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int pageNumber = 0, int size = 20)
        {
            return GetList(predicate, orderBy, include, pageNumber, size, enableTracking: false);
        }

        public IPaginate<TResult> GetList<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int pageNumber = 0, int size = 20) where TResult : class
        {
            return GetList(selector, predicate, orderBy, include, pageNumber, size, enableTracking: false);
        }
    }
}
