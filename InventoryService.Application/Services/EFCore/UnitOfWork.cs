using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NorthwindService.Application.Services.Abstract;
using NorthwindService.Application.Services.Abstract.Factory;
using NorthwindService.Application.Services.Abstract.UnitOfWork;
using NorthwindService.Application.Services.Concrete;
using NorthwindService.Domain.Entities;

namespace NorthwindService.Application.Services.EFCore
{
    public class UnitOfWork<TContext>(TContext context, IHttpContextAccessor httpContextAccessor) : IRepositoryFactory,
        IUnitOfWork<TContext>, IUnitOfWork, IDisposable
        where TContext : DbContext, IDisposable
    {
        private Dictionary<(Type type, string name), object> _repositories;

        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? null;

        public TContext Context { get; } = context ?? throw new ArgumentNullException("context");

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