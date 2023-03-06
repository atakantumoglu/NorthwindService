using InventoryService.Domain;
using InventoryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Application.Services.Data
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        //Queryable => Db'ye sorgu atılabilir. Enumarable => Db'den veri gelen hali
        Task<List<T>> GetAllAsync(bool isDeleted, int page = 1, int size = 10);
        Task<T> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(Guid id);
    }
}
