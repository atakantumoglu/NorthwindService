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

        [HttpGet]
        [Route("get-personel-by-id")]
        public async Task<ActionResult> GetById(PersonelUpdateDto personelDto)
        {
            var existingPersonel = await _context.Personels.FindAsync(personelDto.Id);

            if (existingPersonel == null)
            {
                return NotFound();
            }

            _mapper.Map(personelDto, existingPersonel);


            await _context.SaveChangesAsync();

            return Ok(existingPersonel);
        }
        [HttpGet]
        public async Task<ActionResult> GetList(PersonelUpdateDto personelDto)
        {
            var existingPersonel = await _context.Personels.FindAsync(personelDto.Id);

            if (existingPersonel == null)
            {
                return NotFound();
            }

            _mapper.Map(personelDto, existingPersonel);


            await _context.SaveChangesAsync();

            return Ok(existingPersonel);
        }

        [HttpPut]
        public async Task<ActionResult> Update(List<PersonelUpdateDto> personelDto)
        {
            foreach (var item in personelDto)
            {
                var existingPersonel = await _context.Personels.FindAsync(item.Id);
                if (existingPersonel == null)
                {
                    return NotFound();
                }

                _mapper.Map(item, existingPersonel);

            }




            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(PersonelDeleteDto personelDto)
        {
            var existingPersonel = await _context.Personels.FindAsync(personelDto.Id);

            if (existingPersonel == null)
            {
                return NotFound();
            }

            existingPersonel.IsDeleted = true;

            await _context.SaveChangesAsync();

            return Ok(existingPersonel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PersonelCreateDto personelDto)
        {

            var personel = _mapper.Map<Personel>(personelDto);

            var createdEntity = await _context.AddAsync(personel);

            await _context.SaveChangesAsync();

            var personelResponse = _mapper.Map<PersonelResponseDto>(createdEntity.Entity);

            return Ok(personelResponse);

        }
    }
}
