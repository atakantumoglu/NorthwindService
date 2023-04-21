using AutoMapper;
using InventoryService.Application.Dtos.UserDtos;
using InventoryService.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace InventoryService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IPersonelRepository _personelRepository;
        private readonly IMapper _mapper;

        public UserController(IPersonelRepository personelRepository, IMapper mapper)
        {
            _personelRepository = personelRepository;
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
