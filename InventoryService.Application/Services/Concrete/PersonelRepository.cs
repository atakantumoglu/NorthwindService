using AutoMapper;
using InventoryService.Application.Dtos.PersonelDtos;
using InventoryService.Application.Services.Abstract;
using InventoryService.Application.Services.Data.EFCore;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.ContextDb;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Application.Services.Concrete
{
    public class PersonelRepository : EFCoreRepository<Personel>, IPersonelRepository
    {
        public PersonelRepository(DbContext context) : base(context)
        {
        }
        
    }
}
