using NorthwindService.Application.ResponseObjects;
using MediatR;

namespace NorthwindService.Application.Cqrs.Commands.CustomerCommands
{
    public class CustomerUpdateCommand : IRequest<ApiResponse>
    {
        public Guid CustomerId { get; set; }
    }
}
