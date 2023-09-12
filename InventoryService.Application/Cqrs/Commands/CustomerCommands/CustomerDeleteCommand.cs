using NorthwindService.Application.ResponseObjects;
using MediatR;

namespace NorthwindService.Application.Cqrs.Commands.CustomerCommands
{
    public class CustomerDeleteCommand : IRequest<ApiResponse>
    {
    }
}
