using AutoMapper;
using InventoryService.Application.Dtos.PersonelDtos;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.Mapper.PersonelMapper
{
    public class PersonelMapperProfile : Profile
    {
        public PersonelMapperProfile()
        {
            CreateMap<Personel, PersonelUpdateDto>().ReverseMap();
            CreateMap<Personel, PersonelCreateDto>().ReverseMap();
            CreateMap<PersonelResponseDto, Personel>().ReverseMap().ForPath(dest => dest.FullName, s => s.MapFrom(x => x.FirstName + " " + x.LastName));
            CreateMap<Personel, PersonelDeleteDto>().ReverseMap();
            CreateMap<Personel, GetPersonelListDto>().ReverseMap();
        }
    }
}
