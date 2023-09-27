using NorthwindService.Application.Services.Data.Abstract;
using NorthwindService.Application.Services.Data.Abstract.Factory;
using NorthwindService.Application.Services.Data.Abstract.UnitOfWork;
using NorthwindService.Application.Services.Data.Concrete;
using NorthwindService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace NorthwindService.Application.Services.Data.EFCore
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext>, IUnitOfWork, IDisposable where TContext : DbContext, IDisposable
    {
        private Dictionary<(Type type, string name), object> _repositories;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public TContext Context { get; }

        public UnitOfWork(TContext context, IHttpContextAccessor httpContextAccessor)
        {
            Context = context ?? throw new ArgumentNullException("context");
            _httpContextAccessor = httpContextAccessor ?? null;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            return (IRepository<TEntity>)GetOrAddRepository(typeof(TEntity), new Repository<TEntity>(Context, _httpContextAccessor));
        }

        public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : BaseEntity
        {
            return (IRepositoryAsync<TEntity>)GetOrAddRepository(typeof(TEntity), new RepositoryAsync<TEntity>(Context, _httpContextAccessor));
        }

        public IRepositoryReadOnly<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : BaseEntity
        {
            return (IRepositoryReadOnly<TEntity>)GetOrAddRepository(typeof(TEntity), new RepositoryReadOnly<TEntity>(Context));
        }

        public IRepositoryReadOnlyAsync<TEntity> GetReadOnlyRepositoryAsync<TEntity>() where TEntity : BaseEntity
        {
            return (IRepositoryReadOnlyAsync<TEntity>)GetOrAddRepository(typeof(TEntity), new RepositoryReadOnlyAsync<TEntity>(Context, _httpContextAccessor));
        }

        public IDeleteRepository<TEntity> DeleteRepository<TEntity>() where TEntity : BaseEntity
        {
            return (IDeleteRepository<TEntity>)GetOrAddRepository(typeof(TEntity), new DeleteRepository<TEntity>(Context, _httpContextAccessor));
        }

        public int Commit(bool autoHistory = false)
        {
            if (autoHistory)
            {
                Context.EnsureAutoHistory();
            }

            return Context.SaveChanges();
        }

        public async Task<int> CommitAsync(bool autoHistory = false)
        {
            if (autoHistory)
            {
                Context.EnsureAutoHistory();
            }

            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        internal object GetOrAddRepository(Type type, object repo)
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<(Type, string), object>();
            }

            if (_repositories.TryGetValue((type, repo.GetType().FullName), out var value))
            {
                return value;
            }

            _repositories.Add((type, repo.GetType().FullName), repo);
            return repo;
        }
    }

}