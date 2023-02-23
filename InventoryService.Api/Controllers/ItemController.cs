using InventoryService.Application.Dtos.ItemDtos;
using InventoryService.Application.Dtos.PersonelDtos;
using InventoryService.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;


        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateItem(ItemCreateDto itemDto)
        {
            var result = await _itemService.ItemCreate(itemDto);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateItem(ItemUpdateDto itemDto)
        {
            var result = await _itemService.ItemUpdate(itemDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteItem(ItemDeleteDto itemDto)
        {
            var result = await _itemService.ItemDelete(itemDto);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-item-by-id")]
        public async Task<ActionResult> GetByIdItem(Guid Id)
        {
            var result = await _itemService.GetItemById(Id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetItemList(bool IsDeleted, int page = 1, int pageSize = 10)
        {
            var result = _itemService.GetItemList(IsDeleted, page, pageSize);
            return Ok();
        }
    }
}
