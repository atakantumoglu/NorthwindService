using InventoryService.Application.ResponseObjects;
using MediatR;

namespace InventoryService.Application.Cqrs.Commands.CustomerCommands
{
    public class CustomerUpdateCommand : IRequest<ApiResponse>
    {
        public Guid CustomerId { get; set; }
    }
}
