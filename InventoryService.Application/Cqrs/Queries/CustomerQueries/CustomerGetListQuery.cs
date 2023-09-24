using NorthwindService.Application.ResponseObjects;
using MediatR;

namespace NorthwindService.Application.Cqrs.Queries.CustomerQueries
{
    public record CustomerGetListQuery : IRequest<ApiResponse>
    {
    }
}
