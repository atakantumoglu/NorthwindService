using AutoMapper;
using InventoryService.Application.Dtos.ItemDtos;
using InventoryService.Application.Services.Data.Abstract;
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
            await _context.CommitAsync();

            return Ok(result.Entity);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateItem(ItemUpdateDto itemDto)
        {
            var data = _mapper.Map<Item>(itemDto);

            _context.GetRepository<Item>().Update(data);
            await _context.CommitAsync();
            return Ok(data);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("get-item-by-id")]
        public async Task<ActionResult> GetByIdItem(Guid Id)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetItemList(bool IsDeleted, int page = 1, int size = 10)
        {
            return Ok();
        }
    }
}
