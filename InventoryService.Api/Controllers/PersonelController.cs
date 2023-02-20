using AutoMapper;
using InventoryService.Application.Dtos.PersonelDtos;
using InventoryService.Application.Services;
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
            var existingId = await _context.Personels.FirstOrDefaultAsync(x => x.IsDeleted.Equals(false) && x.Id.Equals(Id));

            var data = _mapper.Map<PersonelResponseDto>(existingId);

            return Ok(data);
        }
        [HttpGet]
        public async Task<ActionResult> GetList(bool IsDeleted, int page = 1, int pageSize = 10)
        {
           
            var existingPersonel =  _context.Personels.Where(x => x.IsDeleted.Equals(IsDeleted))
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            var totalRecords = await existingPersonel.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            var data = _mapper.Map<List<PersonelResponseDto>>(await existingPersonel.ToListAsync());

            return Ok(new { data, totalRecords, totalPages });
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
