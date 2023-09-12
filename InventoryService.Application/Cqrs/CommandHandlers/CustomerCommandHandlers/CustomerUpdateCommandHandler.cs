using InventoryService.Application.Cqrs.Commands.CustomerCommands;
using InventoryService.Application.ResponseObjects;
using MediatR;

namespace InventoryService.Application.Cqrs.CommandHandlers.CustomerCommandHandlers
{
    public class CustomerUpdateCommandHandler : IRequestHandler<CustomerUpdateCommand, ApiResponse>
    {
        public Task<ApiResponse> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
