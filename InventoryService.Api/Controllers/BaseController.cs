using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindService.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T>(IMediator mediator, IHttpContextAccessor contextAccessor) : ControllerBase
        where T : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IHttpContextAccessor _contextAccessor = contextAccessor;
    }
}
