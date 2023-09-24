using NorthwindService.Application.Cqrs.Commands.CustomerCommands;
using NorthwindService.Application.ResponseObjects;
using MediatR;
using NorthwindService.Application.Services.Data.Abstract;
using NorthwindService.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using NorthwindService.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace NorthwindService.Application.Cqrs.CommandHandlers.CustomerCommandHandlers
{
    public sealed class CustomerCreateCommandHandler : IRequestHandler<CustomerCreateCommand, ApiResponse>
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerCreateCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            Customer mappedCustomer = _mapper.Map<Customer>(request);
            var entity = await _unitOfWork.GetRepositoryAsync<Customer>().InsertAsync(mappedCustomer);
            await _unitOfWork.CommitAsync();

            return new ApiResponse()
            {
                Data = entity,
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}