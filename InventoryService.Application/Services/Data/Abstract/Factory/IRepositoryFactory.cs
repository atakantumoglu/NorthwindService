using NorthwindService.Domain.Entities;

namespace NorthwindService.Application.Services.Data.Abstract.Factory
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        IRepositoryAsync<T> GetRepositoryAsync<T>() where T : BaseEntity;
        IRepositoryReadOnly<T> GetReadOnlyRepository<T>() where T : BaseEntity;
    }
}
