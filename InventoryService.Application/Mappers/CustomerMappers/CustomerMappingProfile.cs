using AutoMapper;
using InventoryService.Application.Dtos.CustomerDtos;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.Mappers.CustomerMappers
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerGetByIdDto>().ReverseMap();
            CreateMap<Customer, CustomerCreateDto>().ReverseMap();
            CreateMap<Customer, CustomerGetListDto>().ReverseMap();
            CreateMap<CustomerGetByIdDto, CustomerGetListDto>().ReverseMap();


        }
    }
}
