using InventoryService.Application.Cqrs.Commands.CustomerCommands;
using InventoryService.Application.ResponseObjects;
using MediatR;

namespace InventoryService.Application.Cqrs.CommandHandlers.CustomerCommandHandlers
{
    public class CustomerDeleteCommandHandler : IRequestHandler<CustomerDeleteCommand, ApiResponse>
    {
        public Task<ApiResponse> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
