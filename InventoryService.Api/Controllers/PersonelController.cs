using AutoMapper;
using InventoryService.Application.Dtos.PersonelDtos;
using InventoryService.Application.Services.Abstract;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.ContextDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace InventoryService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonelController : Controller
    {
        private readonly IPersonelService _personelService;

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PersonelController(ApplicationDbContext context, IMapper mapper, IPersonelService personelService)
        {
            _context = context;
            _mapper = mapper;
            _personelService = personelService;
        }

        [HttpGet]
        [Route("get-personel-by-id")]
        public async Task<ActionResult> GetById(Guid Id)
        {
            var result = _personelService.PersonelGetById(Id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetList(bool IsDeleted, int page = 1, int pageSize = 10)
        {
            var result = _personelService.GetPersonelList(IsDeleted, page, pageSize);

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

        [HttpPost]
        public async Task<ActionResult> Create(PersonelCreateDto personelDto)
        {

            var result = await _personelService.CreatePersonel(personelDto);

            return Ok(result);

        }
    }
}
