using AutoMapper;
using InventoryService.Application.Dtos.PersonelDtos;
using InventoryService.Application.Services.Abstract;
using InventoryService.Application.Services.Data.Abstract;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.ContextDb;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PersonelController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Create(PersonelCreateDto personelDto)
        {
            var data = _mapper.Map<Personel>(personelDto);

            var result = await _unitOfWork.PersonelRepository.CreateAsync(data);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(List<PersonelUpdateDto> personelDto)
        {
            var data = _mapper.Map<Personel>(personelDto);
            var result = await _unitOfWork.PersonelRepository.UpdateAsync(data);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.PersonelRepository.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-personel-by-id")]
        public async Task<ActionResult> GetById(Guid Id)
        {
            var result = await _unitOfWork.PersonelRepository.GetByIdAsync(Id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetList(bool IsDeleted, int page = 1, int pageSize = 10)
        {
            var result = await _unitOfWork.PersonelRepository.GetAllAsync(IsDeleted, page, pageSize);
            return Ok(result);
        }
    }
}
