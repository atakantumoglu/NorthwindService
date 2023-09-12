using NorthwindService.Application.ResponseObjects;
using MediatR;

namespace NorthwindService.Application.Cqrs.Queries.CustomerQueries
{
    public class CustomerGetByIdQuery : IRequest<ApiResponse>
    {
        public CustomerGetByIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
        public Guid CustomerId { get; set; }
    }
}
