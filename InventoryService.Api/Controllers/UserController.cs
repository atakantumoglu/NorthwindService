using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorthwindService.Application.Cqrs.Commands.UserCommands;
using NorthwindService.Application.Cqrs.Queries.UserQueries;

namespace NorthwindService.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController(IMediator mediator) : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Create(UserCreateCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }
      
        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginQuery query)
        {
            var response = await mediator.Send(query);

            return Ok(response);
        }
    }
}
