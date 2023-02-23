using AutoMapper;
using InventoryService.Application.Dtos.ItemDtos;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.Mapper.ItemMapper
{
    public class ItemMapperProfile : Profile
    {
        public ItemMapperProfile()
        {
            CreateMap<Item, ItemCreateDto>().ReverseMap();
            CreateMap<Item, ItemUpdateDto>().ReverseMap();
            CreateMap<Item, ItemResponseDto>().ReverseMap();
        }
    }
}
