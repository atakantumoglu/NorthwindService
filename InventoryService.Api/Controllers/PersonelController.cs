using AutoMapper;
using InventoryService.Application.Dtos.PersonelDtos;
using InventoryService.Application.Services.Abstract;
using InventoryService.Infrastructure.ContextDb;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonelController : Controller
    {
        private readonly IPersonelService _personelService;

        public PersonelController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(PersonelCreateDto personelDto)
        {
            var result = await _personelService.CreatePersonel(personelDto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(List<PersonelUpdateDto> personelDto)
        {
            var result = await _personelService.UpdatePersonel(personelDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(PersonelDeleteDto personelDto)
        {
            var result = await _personelService.DeletePersonel(personelDto);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-personel-by-id")]
        public async Task<ActionResult> GetById(Guid Id)
        {
            var result = await _personelService.PersonelGetById(Id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetList(bool IsDeleted, int page = 1, int pageSize = 10)
        {
            var result = await _personelService.GetPersonelList(IsDeleted, page, pageSize);
            return Ok(result);
        }    
    }
}
