using MediatR;
using NorthwindService.Application.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindService.Application.Cqrs.Queries.UserQueries
{
    public sealed class UserLoginQuery : IRequest<ApiResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
