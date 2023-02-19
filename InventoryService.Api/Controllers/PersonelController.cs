using AutoMapper;
using InventoryService.Application.Dtos.PersonelDtos;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.ContextDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace InventoryService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonelController : Controller
    {


        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PersonelController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut]
        public async Task<ActionResult> Update(PersonelUpdateDto personelDto)
        {
            var id = from p in _context.Personels where p.Id == personelDto.Id select p;
            var personelUpdate = _mapper.Map<Personal>(personelDto);
          
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PersonelCreateDto personelDto)
        {

            var personel = _mapper.Map<Personal>(personelDto);
  
            var createdEntity = await _context.AddAsync(personel);

            await _context.SaveChangesAsync();

            var personelResponse = _mapper.Map<PersonelResponseDto>(createdEntity.Entity);
        
            return Ok(personelResponse);

        }
    }
}
