using AutoMapper;
using InventoryService.Application.Dtos.PersonelDtos;
using InventoryService.Application.Services.Data.Abstract;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.ContextDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonelController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;

        public PersonelController(IMapper mapper, IUnitOfWork<ApplicationDbContext> unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult> Create(PersonelCreateDto personelDto)
        {
            var data = _mapper.Map<Personel>(personelDto);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(List<PersonelUpdateDto> personelDto)
        {
            var data = _mapper.Map<Personel>(personelDto);
 
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            return Ok();

        }

        [HttpGet]
        [Route("get-personel-by-id")]
        public async Task<ActionResult> GetById(Guid Id)
        {
            return Ok();

        }

        [HttpGet]
        public async Task<ActionResult> GetList(bool IsDeleted, int page = 1, int pageSize = 10)
        {
            return Ok();
        }
    }
}
