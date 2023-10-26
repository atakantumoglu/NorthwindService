﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthwindService.Application.Cqrs.Commands.CustomerCommands;
using NorthwindService.Application.Cqrs.Queries.CustomerQueries;

namespace NorthwindService.Api.Controllers
{
    [ApiController]
    [Route("api/customer")]
    [Authorize]

    public class CustomerController : BaseController<CustomerController>
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;

        public CustomerController(IMediator mediator, IHttpContextAccessor contextAccessor) : base(mediator, contextAccessor)
        {
            _mediator = mediator;
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<ActionResult> GetById(Guid customerId)
        {
            var query = new CustomerGetByIdQuery(customerId);

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult> GetList(int pageNumber, int size, bool isDeleted)
        {
            var query = new CustomerGetListQuery(pageNumber, size, isDeleted);

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CustomerCreateCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Update(CustomerUpdateCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] CustomerDeleteCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
