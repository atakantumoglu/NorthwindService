using AutoMapper;
using InventoryService.Application.Dtos.ItemDtos;
using InventoryService.Application.Services.Abstract;
using InventoryService.Application.Services.Data;
using InventoryService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IRepository<Item> _itemService;
        private readonly IMapper _mapper;
        public ItemController(IRepository<Item> itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateItem(ItemCreateDto itemDto)
        {
            var data = _mapper.Map<Item>(itemDto);
            var result = await _itemService.CreateAsync(data);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateItem(ItemUpdateDto itemDto)
        {
            var data = _mapper.Map<Item>(itemDto);
            var result = await _itemService.UpdateAsync(data);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var result = await _itemService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-item-by-id")]
        public async Task<ActionResult> GetByIdItem(Guid Id)
        {

            var result = await _itemService.GetByIdAsync(Id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetItemList(bool IsDeleted, int page = 1, int size = 10)
        {
            var result = await _itemService.GetAllAsync(IsDeleted, page, size);
            return Ok(result);
        }
    }
}
