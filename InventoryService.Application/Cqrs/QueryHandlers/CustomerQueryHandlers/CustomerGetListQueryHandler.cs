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
    public class CustomerGetListQueryHandler : IRequestHandler<CustomerGetListQuery, ApiResponse>
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerGetListQueryHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(CustomerGetListQuery request, CancellationToken cancellationToken)
        {
            var customerList = await _unitOfWork.GetReadOnlyRepositoryAsync<Customer>().GetListAsync(c => c.IsDeleted.Equals(false));

            if (customerList == null)
            {
                throw new Exception("Cannot retrieve customer list.");
            }


            return new ApiResponse()
            {
                Data = _mapper.Map<List<CustomerGetByIdDto>>(customerList.Items),
                IsSuccessful = true,
                StatusCode = 200,
                TotalItemCount = customerList.Count
            };
        }
    }
}
