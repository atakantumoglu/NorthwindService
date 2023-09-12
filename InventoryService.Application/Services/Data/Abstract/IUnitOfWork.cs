using InventoryService.Domain.Entities;

namespace InventoryService.Application.Services.Data.Abstract.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : BaseEntity;
        IRepositoryReadOnly<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : BaseEntity;
        IRepositoryReadOnlyAsync<TEntity> GetReadOnlyRepositoryAsync<TEntity>() where TEntity : BaseEntity;
        IDeleteRepository<TEntity> DeleteRepository<TEntity>() where TEntity : BaseEntity;
        int Commit(bool autoHistory = false);
        Task<int> CommitAsync(bool autoHistory = false);
    }
}
