using AutoMapper;
using NorthwindService.Application.Cqrs.Queries.CustomerQueries;
using NorthwindService.Application.Dtos.CustomerDtos;
using NorthwindService.Application.ResponseObjects;
using NorthwindService.Application.Services.Data.Abstract;
using NorthwindService.Domain.Entities;
using NorthwindService.Infrastructure.Data.Context;

using MediatR;

namespace NorthwindService.Application.Cqrs.QueryHandlers.CustomerQueryHandlers
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
