using InventoryService.Domain.Entities;
using InventoryService.Domain.Enums;


namespace InventoryService.Application.Dtos.PersonelDtos
{
    public class GetPersonelListDto
    {
        public List<PersonelResponseDto> Data { get; set; }
        public int totalRecords { get; set; }
        public int totalPages { get; set; }
    }
}
