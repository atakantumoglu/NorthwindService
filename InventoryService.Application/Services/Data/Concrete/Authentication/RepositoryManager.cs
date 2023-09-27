using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NorthwindService.Application.Services.Data.Abstract;
using NorthwindService.Application.Services.Data.Abstract.Authentication;
using NorthwindService.Domain.Entities;

namespace NorthwindService.Application.Services.Data.Concrete.Authentication
{
    public class RepositoryManager : IRepositoryManager
    {
        private IdentityDbContext _identityDbContext;
        private IUserAuthenticationRepository _userAuthenticationRepository;
        private UserManager<User> _userManager;
        private IMapper _mapper;
        private IConfiguration _configuration;

        public RepositoryManager(IUserAuthenticationRepository userAuthenticationRepository, UserManager<User> userManager, IMapper mapper, IConfiguration configuration, IdentityDbContext context)
        {
            _userAuthenticationRepository = userAuthenticationRepository;
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
            _identityDbContext = context;
        }

        public IUserAuthenticationRepository UserAuthentication
        {
            get
            {
                if (_userAuthenticationRepository is null)
                    _userAuthenticationRepository = new UserAuthenticationRepository(_userManager, _mapper, _configuration);
                return _userAuthenticationRepository;
            }
        }

        public Task SaveAsync() => _identityDbContext.SaveChangesAsync();

    }
}
