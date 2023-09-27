using Microsoft.AspNetCore.Mvc;
using NorthwindService.Application.Services.Data.Abstract.Authentication;
using NorthwindService.Domain.Entities;

namespace NorthwindService.Api.Controllers
{

    [Route("api/userauthentication")]
    [ApiController]
    public class AuthController : Controller
    {

        private readonly IRepositoryManager _repository;

        public AuthController(IRepositoryManager repo)
        {
            _repository = repo;
        }

        [HttpPost]

        public async Task<IActionResult> RegisterUser([FromBody] User userRegistration)
        {

            var userResult = await _repository.UserAuthentication.RegisterUserAsync(userRegistration);
            return !userResult.Succeeded ? new BadRequestObjectResult(userResult) : StatusCode(201);
        }

        [HttpPost("login")]

        public async Task<IActionResult> Authenticate([FromBody] User user)
        {
            return !await _repository.UserAuthentication.ValidateUserAsync(user)
            ? Unauthorized()
                : Ok(new { Token = await _repository.UserAuthentication.CreateTokenAsync() });
        }

    }
}