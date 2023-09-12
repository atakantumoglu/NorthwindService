using NorthwindService.Application.Cqrs.Commands.CustomerCommands;
using NorthwindService.Application.ResponseObjects;
using MediatR;

namespace NorthwindService.Application.Cqrs.CommandHandlers.CustomerCommandHandlers
{
    public class CustomerCreateCommandHandler : IRequestHandler<CustomerCreateCommand, ApiResponse>
    {
        public Task<ApiResponse> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
