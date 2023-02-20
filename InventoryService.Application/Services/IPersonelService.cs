using InventoryService.Application.Dtos.PersonelDtos;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.Services
{
    public interface IPersonelService
    {
        Task<PersonelResponseDto> CreatePersonel(PersonelCreateDto personelDto);
        Task<Personel> DeletePersonel(PersonelDeleteDto personelDto);
    }
}
