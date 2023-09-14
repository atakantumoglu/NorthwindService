using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using NorthwindService.Application.Cqrs.Commands.CustomerCommands;
using NorthwindService.Application.Dtos.CustomerDtos;
using NorthwindService.Application.ResponseObjects;
using NorthwindService.Application.Services.Data.Abstract;
using NorthwindService.Domain.Entities;
using NorthwindService.Infrastructure.Data.Context;

namespace NorthwindService.Application.Cqrs.CommandHandlers.CustomerCommandHandlers
{
    public class CustomerCreateCommandHandler : IRequestHandler<CustomerCreateCommand, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;

        public CustomerCreateCommandHandler(IMapper mapper, IUnitOfWork<ApplicationDbContext> unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            Customer customer = _mapper.Map<Customer>(request);

            var sdf = await _unitOfWork.GetRepositoryAsync<Customer>().InsertAsync(customer, cancellationToken);

            await _unitOfWork.CommitAsync();

            return new ApiResponse
            {
                Data = customer,
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK,
                Errors = new List<string>() { }
            };

        }
    }
}
