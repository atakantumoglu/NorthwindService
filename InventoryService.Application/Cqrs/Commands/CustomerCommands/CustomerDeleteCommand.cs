using NorthwindService.Application.ResponseObjects;
using MediatR;

namespace NorthwindService.Application.Cqrs.Commands.CustomerCommands
{
    public sealed class CustomerDeleteCommand : IRequest<ApiResponse>
    {
        public Guid CustomerId { get; set; }
    }
}
