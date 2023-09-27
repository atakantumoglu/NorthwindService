using Microsoft.AspNetCore.Identity;
using NorthwindService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindService.Application.Services.Data.Abstract
{
    public interface IUserAuthenticationRepository
    {
        Task<IdentityResult> RegisterUserAsync(User userForRegistration);
        Task<bool> ValidateUserAsync(User loginDto);
        Task<string> CreateTokenAsync();
    }
}
