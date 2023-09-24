﻿using NorthwindService.Application.Cqrs.Queries.CustomerQueries;
using NorthwindService.Application.Services.Data.Abstract;
using NorthwindService.Infrastructure.Data.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorthwindService.Application.Cqrs.Commands.CustomerCommands;

namespace NorthwindService.Api.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IMediator _mediator;
        public CustomerController(IUnitOfWork<ApplicationDbContext> unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
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
        public async Task<ActionResult> GetList()
        {
            var query = new CustomerGetListQuery();

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CustomerCreateCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}