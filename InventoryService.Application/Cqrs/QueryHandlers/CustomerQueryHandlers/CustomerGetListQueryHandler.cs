using NorthwindService.Application.Cqrs.Queries.CustomerQueries;
using NorthwindService.Application.Dtos.CustomerDtos;
using NorthwindService.Application.ResponseObjects;
using NorthwindService.Application.Services.Abstract.UnitOfWork;
using NorthwindService.Domain.Entities;
using NorthwindService.Infrastructure.Data.Context;
using AutoMapper;
using MediatR;

namespace NorthwindService.Application.Cqrs.QueryHandlers.CustomerQueryHandlers
{
    public sealed class CustomerGetListQueryHandler : IRequestHandler<CustomerGetListQuery, ApiResponse>
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

            var customerList = await _unitOfWork.GetReadOnlyRepositoryAsync<Customer>().GetListAsync(pageNumber: request.PageNumber, size: request.Size);

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
