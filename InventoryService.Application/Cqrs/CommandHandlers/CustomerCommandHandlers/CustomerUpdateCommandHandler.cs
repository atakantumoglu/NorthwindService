using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using NorthwindService.Application.Cqrs.Commands.CustomerCommands;
using NorthwindService.Application.ResponseObjects;
using NorthwindService.Application.Services.Data.Abstract;
using NorthwindService.Domain.Entities;
using NorthwindService.Infrastructure.Data.Context;

namespace NorthwindService.Application.Cqrs.CommandHandlers.CustomerCommandHandlers
{
    public sealed class CustomerUpdateCommandHandler : IRequestHandler<CustomerUpdateCommand, ApiResponse>
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerUpdateCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var existingCustomer = await GetExistingCustomer(request.Id);

            UpdateCustomerDetails(existingCustomer, request);

            _unitOfWork.GetRepository<Customer>().Update(existingCustomer);
            _unitOfWork.Commit();

            return CreateSuccessResponse(existingCustomer);
        }

        private async Task<Customer> GetExistingCustomer(Guid customerId)
        {
            var existingCustomer = await _unitOfWork.GetReadOnlyRepositoryAsync<Customer>().SingleOrDefaultAsync(c => c.Id.Equals(customerId));

            if (existingCustomer == null)
            {
                throw new CustomerNotFoundException("Customer cannot be found");
            }

            return existingCustomer;
        }

        private void UpdateCustomerDetails(Customer customer, CustomerUpdateCommand request)
        {
            customer.ContactName = request.ContactName;
            customer.ContactTitle = request.ContactTitle;
            customer.Address = request.Address;
            customer.City = request.City;
            customer.Country = request.Country;
            customer.Region = request.Region;
            customer.PostalCode = request.PostalCode;
            customer.Phone = request.Phone;
            customer.Fax = request.Fax;
            customer.CompanyName = request.CompanyName;
        }

        private ApiResponse CreateSuccessResponse(Customer updatedCustomer)
        {
            return new ApiResponse()
            {
                Data = updatedCustomer,
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK
            };
        }
    }

    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string message) : base(message) { }
    }
}
