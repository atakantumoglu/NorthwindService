using AutoMapper;
using InventoryService.Application.Dtos.ItemDtos;
using InventoryService.Application.Services.Abstract;
using InventoryService.Application.Services.Data;
using InventoryService.Application.Services.Data.Abstract;
using InventoryService.Application.Services.Data.Abstract.UnitOfWork;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.ContextDb;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ItemController : Controller
    {
        private  IUnitOfWork<ApplicationDbContext> _context { get; set; }
        private readonly IMapper _mapper;

        public ItemController(IUnitOfWork<ApplicationDbContext> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateItem(ItemCreateDto itemDto)
        {
            var data = _mapper.Map<Item>(itemDto);
            var result = await _context.GetRepositoryAsync<Item>().InsertAsync(data);

            return Ok(result.Entity);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateItem(ItemUpdateDto itemDto)
        {
            var data = _mapper.Map<Item>(itemDto);

            _context.GetRepository<Item>().Update(data);
            _context.Commit();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            ////var result = await _itemService.DeleteAsync(id);
            //return Ok(result);
            return Ok();

        }

        [HttpGet]
        [Route("get-item-by-id")]
        public async Task<ActionResult> GetByIdItem(Guid Id)
        {

            //var result = await _itemService.GetByIdAsync(Id);
            //return Ok(result);
            return Ok();

        }

        [HttpGet]
        public async Task<ActionResult> GetItemList(bool IsDeleted, int page = 1, int size = 10)
        {
            //var result = await _itemService.GetAllAsync(IsDeleted, page, size);
            //return Ok(result);
            return Ok();

        }
    }
}
