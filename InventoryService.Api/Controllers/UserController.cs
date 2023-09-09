using AutoMapper;
using InventoryService.Application.Dtos.UserDtos;
using InventoryService.Application.Services.Data.Abstract;
using InventoryService.Infrastructure.ContextDb;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork<ApplicationDbContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserCreateDto userDto)
        {
            var data = _mapper.Map<UserCreateDto>(userDto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(UserUpdateDto userDto)
        {
            var data = _mapper.Map<UserUpdateDto>(userDto);
            return Ok();
        }
    }
}
