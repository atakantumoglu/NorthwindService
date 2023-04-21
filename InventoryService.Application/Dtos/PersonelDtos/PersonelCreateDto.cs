using InventoryService.Domain.Enums;

namespace InventoryService.Application.Dtos.PersonelDtos
{
    public class PersonelCreateDto
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public TitleEnum TitleId { get; set; }
        public string TCKN { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
