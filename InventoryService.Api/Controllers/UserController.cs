using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorthwindService.Application.Cqrs.Commands.UserCommands;
using NorthwindService.Application.Cqrs.Queries.UserQueries;
using NorthwindService.Application.Services.Data.Abstract;
using NorthwindService.Infrastructure.Data.Context;

namespace NorthwindService.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult> Create(UserCreateCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
      
        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginQuery command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
