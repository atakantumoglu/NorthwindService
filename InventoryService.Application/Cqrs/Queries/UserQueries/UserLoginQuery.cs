using MediatR;
using NorthwindService.Application.ResponseObjects;

namespace NorthwindService.Application.Cqrs.Queries.UserQueries
{
    public sealed class UserLoginQuery : IRequest<ApiResponse>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
