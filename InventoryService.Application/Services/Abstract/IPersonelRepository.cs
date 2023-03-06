using InventoryService.Application.Dtos.PersonelDtos;
using InventoryService.Application.Services.Data;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.Services.Abstract
{
    public interface IPersonelRepository : IRepository<Personel>
    {
    }
}
