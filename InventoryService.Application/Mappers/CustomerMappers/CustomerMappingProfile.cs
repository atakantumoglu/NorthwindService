﻿using AutoMapper;
using NorthwindService.Application.Cqrs.Commands.CustomerCommands;
using NorthwindService.Application.Dtos.CustomerDtos;
using NorthwindService.Domain.Entities;

namespace NorthwindService.Application.Mappers.CustomerMappers
{
    public sealed class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerGetByIdDto>().ReverseMap();
            CreateMap<Customer, CustomerCreateCommand>().ReverseMap();
            CreateMap<Customer, CustomerCreateDto>().ReverseMap();
            CreateMap<Customer, CustomerGetListDto>().ReverseMap();
            CreateMap<CustomerGetByIdDto, CustomerGetListDto>().ReverseMap();
            CreateMap<Customer, CustomerUpdateDto>().ReverseMap();
        }
    }
}
