using InventoryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Application.Services.Data.Abstract
{
    public interface IDeleteRepository<T> where T : BaseEntity
    {
        void SoftDelete(T entity);
    }
}
