using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorthwindService.Application.Cqrs.Commands.CustomerCommands;
using NorthwindService.Application.Cqrs.Commands.UserCommands;
using NorthwindService.Application.Services.Data.Abstract;
using NorthwindService.Infrastructure.Data.Context;

namespace NorthwindService.Api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IMediator _mediator;

        public UserController(IUnitOfWork<ApplicationDbContext> unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult> Create(UserCreateCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
