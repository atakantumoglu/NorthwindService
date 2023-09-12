using InventoryService.Application.Cqrs.Commands.CustomerCommands;
using InventoryService.Application.ResponseObjects;
using MediatR;

namespace InventoryService.Application.Cqrs.CommandHandlers.CustomerCommandHandlers
{
    public class CustomerCreateCommandHandler : IRequestHandler<CustomerCreateCommand, ApiResponse>
    {
        public Task<ApiResponse> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
