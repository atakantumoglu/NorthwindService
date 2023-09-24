using NorthwindService.Application.ResponseObjects;
using MediatR;

namespace NorthwindService.Application.Cqrs.Commands.CustomerCommands
{
    public record CustomerUpdateCommand : IRequest<ApiResponse>
    {
        public Guid CustomerId { get; set; }
    }
}
