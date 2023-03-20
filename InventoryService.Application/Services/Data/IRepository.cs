using InventoryService.Domain;

namespace InventoryService.Application.Services.Data
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        Task<List<T>> GetAllAsync(bool isDeleted, int page = 1, int size = 10);
        Task<T> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(Guid id);
    }
}
