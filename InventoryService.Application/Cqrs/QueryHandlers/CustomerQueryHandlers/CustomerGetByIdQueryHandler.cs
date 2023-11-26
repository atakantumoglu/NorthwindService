using AutoMapper;
using MediatR;
using NorthwindService.Application.Cqrs.Queries.CustomerQueries;
using NorthwindService.Application.Dtos.CustomerDtos;
using NorthwindService.Application.ResponseObjects;
using NorthwindService.Application.Services.Abstract.UnitOfWork;
using NorthwindService.Domain.Entities;
using NorthwindService.Infrastructure.Data.Context;

namespace NorthwindService.Application.Cqrs.QueryHandlers.CustomerQueryHandlers
{
    public sealed class CustomerGetByIdQueryHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, IMapper mapper)
        : IRequestHandler<CustomerGetByIdQuery, ApiResponse>
    {
        public async Task<ApiResponse> Handle(CustomerGetByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadOnlyRepositoryAsync<Customer>().SingleOrDefaultAsync(c => c.Id.Equals(request.CustomerId));

            if (data == null)
            {
                throw new Exception("Customer cannot be found ");
            }

            return new ApiResponse()
            {
                Data = mapper.Map<CustomerGetByIdDto>(data),
                IsSuccessful = true,
                StatusCode = 200,
            };
        }
    }
}
