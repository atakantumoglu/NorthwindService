using AutoMapper;
using InventoryService.Application.Dtos.ItemDtos;
using InventoryService.Application.Services.Abstract;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.ContextDb;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Application.Services.Concrete
{
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ItemService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ItemResponseDto> ItemCreate(ItemCreateDto itemDto)
        {
            var item = _mapper.Map<Item>(itemDto);

            var createdEntity = await _context.AddAsync(item);

            await _context.SaveChangesAsync();

            var itemResponse = _mapper.Map<ItemResponseDto>(createdEntity.Entity);

            return itemResponse;
        }
        public async Task<Item> ItemUpdate(ItemUpdateDto itemDto)
        {
            var existingItem = await _context.Items.FindAsync(itemDto.Id);
            if (existingItem != null)
            {
                _mapper.Map(itemDto, existingItem);
                await _context.SaveChangesAsync();
            }
            return existingItem;
        }
        public async Task<Item> ItemDelete(ItemDeleteDto itemDto)
        {
            var existingItem = await _context.Items.FindAsync(itemDto.Id);
            if (existingItem == null)
            {
                throw new Exception("Ürün bulunamadı!");
            }

            existingItem.IsDeleted = true;

            await _context.SaveChangesAsync();

            return existingItem;
        }
        public async Task<ItemResponseDto> GetItemById(Guid id)
        {
            var existingId = await _context.Items.FirstOrDefaultAsync(x => x.IsDeleted.Equals(false) && x.Id.Equals(id));
            var result = _mapper.Map<ItemResponseDto>(existingId);
            return result;
        }
        public async Task<GetItemListDto> GetItemList(bool IsDeleted, int page = 1, int pageSize = 10)
        {
            var existingItem = _context.Items.Where(x => x.IsDeleted.Equals(IsDeleted))
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

            var totalRecords = await existingItem.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            var data = _mapper.Map<List<ItemResponseDto>>(await existingItem.ToListAsync());

            return new GetItemListDto
            {
                Data = data,
                totalPages = totalPages,
                totalRecords = totalRecords
            };
        }

    }

}
