using AutoMapper;
using InventoryService.Application.Dtos.PersonelDtos;
using InventoryService.Application.Services.Abstract;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.ContextDb;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonelController : Controller
    {
        private readonly IPersonelRepository _personelService;
        private readonly IMapper _mapper;
        public PersonelController(IPersonelRepository personelService)
        {
            _personelService = personelService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(PersonelCreateDto personelDto)
        {
            var data = _mapper.Map<Personel>(personelDto);
            var result = await _personelService.CreateAsync(data);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(List<PersonelUpdateDto> personelDto)
        {
            var data = _mapper.Map<Personel>(personelDto);
            var result = await _personelService.UpdateAsync(data);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {           
            var result = await _personelService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-personel-by-id")]
        public async Task<ActionResult> GetById(Guid Id)
        {
            var result = await _personelService.GetByIdAsync(Id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetList(bool IsDeleted, int page = 1, int pageSize = 10)
        {
            var result = await _personelService.GetAllAsync(IsDeleted, page, pageSize);
            return Ok(result);
        }    
    }
}
