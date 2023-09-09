using InventoryService.Domain.Entities;

namespace InventoryService.Application.Services.Data.Abstract
{
    public interface IDeleteRepository<T> where T : BaseEntity
    {
        void SoftDelete(T entity);
    }
}
