using MediatR;
using NorthwindService.Application.ResponseObjects;

namespace NorthwindService.Application.Cqrs.Commands.UserCommands
{
    public sealed class UserCreateCommand : IRequest<ApiResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
