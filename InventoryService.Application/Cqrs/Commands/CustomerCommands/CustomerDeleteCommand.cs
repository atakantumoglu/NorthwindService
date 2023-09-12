using InventoryService.Application.ResponseObjects;
using MediatR;

namespace InventoryService.Application.Cqrs.Commands.CustomerCommands
{
    public class CustomerDeleteCommand : IRequest<ApiResponse>
    {
    }
}
