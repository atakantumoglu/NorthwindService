using NorthwindService.Domain.Entities;

namespace NorthwindService.Application.Services.Data.Abstract
{
    public interface IDeleteRepository<T> where T : BaseEntity
    {
        void SoftDelete(T entity);
    }
}
