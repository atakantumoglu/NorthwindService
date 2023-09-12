using InventoryService.Application.Cqrs.Queries.CustomerQueries;
using InventoryService.Application.ResponseObjects;
using InventoryService.Application.Services.Data.Abstract;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.Data.Context;

using MediatR;

namespace InventoryService.Application.Cqrs.QueryHandlers.CustomerQueryHandlers
{
    public class CustomerGetByIdQueryHandler : IRequestHandler<CustomerGetByIdQuery, ApiResponse>
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;

        public CustomerGetByIdQueryHandler(IUnitOfWork<ApplicationDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> Handle(CustomerGetByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.GetReadOnlyRepositoryAsync<Customer>().SingleOrDefaultAsync(c => c.Id.Equals(request.CustomerId));

            if (data == null)
            {
                throw new Exception("Müşteri bulunamadı.");
            }

            return new ApiResponse()
            {
                Data = data,
                IsSuccessful = true,
                StatusCode = 200,
            };
        }
    }
}
