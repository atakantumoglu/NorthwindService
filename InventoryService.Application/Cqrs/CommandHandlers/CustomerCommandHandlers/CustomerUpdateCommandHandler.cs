using NorthwindService.Application.Cqrs.Commands.CustomerCommands;
using NorthwindService.Application.ResponseObjects;
using MediatR;

namespace NorthwindService.Application.Cqrs.CommandHandlers.CustomerCommandHandlers
{
    public class CustomerUpdateCommandHandler : IRequestHandler<CustomerUpdateCommand, ApiResponse>
    {
        public Task<ApiResponse> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
