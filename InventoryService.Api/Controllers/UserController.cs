using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NorthwindService.Application.Cqrs.Commands.CustomerCommands;
using NorthwindService.Application.Cqrs.Commands.UserCommands;
using NorthwindService.Application.Cqrs.Queries.UserQueries;
using NorthwindService.Application.Services.Data.Abstract;
using NorthwindService.Infrastructure.Data.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NorthwindService.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
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
      
        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginQuery command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
