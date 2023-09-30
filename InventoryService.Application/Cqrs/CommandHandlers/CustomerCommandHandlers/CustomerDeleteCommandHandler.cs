using MediatR;
using Microsoft.AspNetCore.Http;
using NorthwindService.Application.Cqrs.Commands.CustomerCommands;
using NorthwindService.Application.ResponseObjects;
using NorthwindService.Application.Services.Data.Abstract;
using NorthwindService.Domain.Entities;
using NorthwindService.Infrastructure.Data.Context;

namespace NorthwindService.Application.Cqrs.CommandHandlers.CustomerCommandHandlers
{
    public sealed class CustomerDeleteCommandHandler : IRequestHandler<CustomerDeleteCommand, ApiResponse>
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;

        public CustomerDeleteCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
        {
            var existingCustomer = await FindCustomerByIdAsync(request.CustomerId);

            SoftDeleteCustomer(existingCustomer);

            _unitOfWork.Commit();

            return CreateSuccessResponse(existingCustomer);
        }

        private async Task<Customer> FindCustomerByIdAsync(Guid customerId)
        {
            var customer = await _unitOfWork.GetReadOnlyRepositoryAsync<Customer>().SingleOrDefaultAsync(c => c.Id.Equals(customerId));

            if (customer == null)
            {
                throw new CustomerNotFoundException("Customer cannot be found");
            }

            return customer;
        }

        private void SoftDeleteCustomer(Customer customer)
        {
            _unitOfWork.DeleteRepository<Customer>().SoftDelete(customer);
        }

        private ApiResponse CreateSuccessResponse(Customer deletedCustomer)
        {
            return new ApiResponse()
            {
                Data = deletedCustomer,
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}
