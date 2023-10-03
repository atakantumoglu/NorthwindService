using AutoMapper;
using NorthwindService.Application.Cqrs.Commands.UserCommands;
using NorthwindService.Application.Dtos.UserDtos;
using NorthwindService.Domain.Entities;

namespace NorthwindService.Application.Mappers.UserMappers
{
    public sealed class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserCreateCommand>().ReverseMap();

        }
    }
}
