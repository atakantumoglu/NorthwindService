using AutoMapper;
using InventoryService.Application.Dtos.PersonelDtos;
using InventoryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Application.Mapper.PersonelMapper
{
    public class PersonelMappingProfile : Profile
    {
        public PersonelMappingProfile()
        {
            CreateMap<Personel, PersonelUpdateDto>().ReverseMap();
            CreateMap<Personel, PersonelCreateDto>().ReverseMap();
            CreateMap<PersonelResponseDto, Personel>().ReverseMap().ForPath(dest => dest.FullName, s => s.MapFrom(x => x.FirstName + " " + x.LastName));
            CreateMap<Personel, PersonelDeleteDto>().ReverseMap();
        }
    }
}
