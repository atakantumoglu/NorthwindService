using InventoryService.Application.ResponseObjects;
using MediatR;

namespace InventoryService.Application.Cqrs.Queries.CustomerQueries
{
    public class CustomerGetListQuery : IRequest<ApiResponse>
    {
    }
}
