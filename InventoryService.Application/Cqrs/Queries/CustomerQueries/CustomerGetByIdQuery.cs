using NorthwindService.Application.ResponseObjects;
using MediatR;

namespace NorthwindService.Application.Cqrs.Queries.CustomerQueries
{
    public record CustomerGetByIdQuery(Guid CustomerId) : IRequest<ApiResponse>
    {
        public Guid CustomerId { get; set; } = CustomerId;
    }
}
