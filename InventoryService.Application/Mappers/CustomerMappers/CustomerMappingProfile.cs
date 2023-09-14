using AutoMapper;
using NorthwindService.Application.Cqrs.Commands.CustomerCommands;
using NorthwindService.Application.Dtos.CustomerDtos;
using NorthwindService.Domain.Entities;

namespace NorthwindService.Application.Mappers.CustomerMappers
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerGetByIdDto>().ReverseMap();
            CreateMap<Customer, CustomerCreateDto>().ReverseMap();
            CreateMap<Customer, CustomerGetListDto>().ReverseMap();
            CreateMap<CustomerGetByIdDto, CustomerGetListDto>().ReverseMap();
            CreateMap<Customer, CustomerCreateCommand>().ReverseMap();


        }
    }
}
