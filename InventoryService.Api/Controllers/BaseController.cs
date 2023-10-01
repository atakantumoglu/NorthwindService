using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NorthwindService.Application.Services.Data.Abstract;
using NorthwindService.Infrastructure.Data.Context;

namespace NorthwindService.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogger<T> _logger;

        public BaseController(IMediator mediator, IHttpContextAccessor contextAccessor, ILogger<T> logger)
        {
            _mediator = mediator;
            _contextAccessor = contextAccessor;
            _logger = logger;
        }
    }
}
