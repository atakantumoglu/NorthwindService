using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NorthwindService.Application.Cqrs.Commands.CustomerCommands;
using NorthwindService.Application.ResponseObjects;
using NorthwindService.Application.Services.Abstract.UnitOfWork;
using NorthwindService.Domain.Entities;
using NorthwindService.Infrastructure.Data.Context;

namespace NorthwindService.Application.Cqrs.CommandHandlers.CustomerCommandHandlers
{
    public sealed class CustomerCreateCommandHandler : IRequestHandler<CustomerCreateCommand, ApiResponse>
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerCreateCommandHandler> _logger;

        public CustomerCreateCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, IMapper mapper, ILogger<CustomerCreateCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResponse> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            var newCustomer = MapRequestToCustomer(request);
            var savedCustomer = await SaveNewCustomerAsync(newCustomer);

            return CreateSuccessResponse(savedCustomer);
        }

        private Customer MapRequestToCustomer(CustomerCreateCommand request)
        {
            return _mapper.Map<Customer>(request);
        }

        private async Task<Customer> SaveNewCustomerAsync(Customer customer)
        {
            var entity = await _unitOfWork.GetRepositoryAsync<Customer>().InsertAsync(customer);
            await _unitOfWork.CommitAsync();
            return entity.Entity;
        }

        private ApiResponse CreateSuccessResponse(Customer savedCustomer)
        {
            return new ApiResponse()
            {
                Data = savedCustomer,
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}
