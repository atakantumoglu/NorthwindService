using AutoMapper;
using InventoryService.Application.Cqrs.Queries.CustomerQueries;
using InventoryService.Application.Dtos.CustomerDtos;
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
        private readonly IMapper _mapper;

        public CustomerGetByIdQueryHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(CustomerGetByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.GetReadOnlyRepositoryAsync<Customer>().SingleOrDefaultAsync(c => c.Id.Equals(request.CustomerId));

            if (data == null)
            {
                throw new Exception("Customer cannot be found ");
            }

            return new ApiResponse()
            {
                Data = _mapper.Map<CustomerGetByIdDto>(data),
                IsSuccessful = true,
                StatusCode = 200,
            };
        }
    }
}
