using InventoryService.Application.Dtos.PersonelDtos;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.Services.Abstract
{
    public interface IPersonelService
    {
        Task<PersonelResponseDto> CreatePersonel(PersonelCreateDto personelDto);
        Task<Personel> DeletePersonel(PersonelDeleteDto personelDto);
        Task<GetPersonelListDto> GetPersonelList(bool isDeleted, int page = 1, int pageSize = 10);
        Task<List<Guid>> UpdatePersonel(List<PersonelUpdateDto> personelDto);
        Task<PersonelResponseDto> PersonelGetById(Guid id);
    }
}
