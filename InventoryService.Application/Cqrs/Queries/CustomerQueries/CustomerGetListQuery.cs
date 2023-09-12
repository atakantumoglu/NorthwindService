using NorthwindService.Application.ResponseObjects;
using MediatR;

namespace NorthwindService.Application.Cqrs.Queries.CustomerQueries
{
    public class CustomerGetListQuery : IRequest<ApiResponse>
    {
    }
}
