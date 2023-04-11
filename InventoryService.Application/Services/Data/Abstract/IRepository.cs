﻿using InventoryService.Domain;
using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace InventoryService.Application.Services.Data.Abstract
{
    public interface IRepository<T> : IReadRepository<T>, IDisposable where T : BaseEntity
    {
        T SingleOrDefault(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool enableTracking = true, bool ignoreQueryFilters = false);

        T Insert(T entity);

        void Insert(IEnumerable<T> entities);

        T InsertNotExists(Expression<Func<T, bool>> predicate, T entity);

        void Update(T entity);

        void Update(IEnumerable<T> entities);
    }
}
