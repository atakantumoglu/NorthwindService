

using Microsoft.AspNetCore.Identity;

namespace NorthwindService.Domain.Entities

{
    public sealed class User : IdentityUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
