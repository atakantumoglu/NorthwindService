using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using NorthwindService.Application.Cqrs.Commands.UserCommands;
using NorthwindService.Application.ResponseObjects;
using NorthwindService.Application.Services.Abstract.UnitOfWork;
using NorthwindService.Application.Services.Helpers;
using NorthwindService.Domain.Entities;
using NorthwindService.Infrastructure.Data.Context;

namespace NorthwindService.Application.Cqrs.CommandHandlers.UserCommandHandlers
{
    public sealed class UserCreateCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, IMapper mapper)
        : IRequestHandler<UserCreateCommand, ApiResponse>
    {
        public async Task<ApiResponse> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var hashedSaltedPassword = CryptoHelper.GetSaltedHashedPassword(request.Password);

            User user = await unitOfWork.GetReadOnlyRepositoryAsync<User>().SingleOrDefaultAsync(u => u.Email.Equals(request.Email));
            if (user != null)
            {
                throw new Exception("This account is already exists");
            }

            var mappedUser = mapper.Map<User>(request);
            mappedUser.Salt = hashedSaltedPassword.salt;
            mappedUser.Password = hashedSaltedPassword.hashedPassword;

            await unitOfWork.GetRepositoryAsync<User>().InsertAsync(mappedUser, cancellationToken);

            await unitOfWork.CommitAsync();


            return new ApiResponse()
            {
                Data = request,
                IsSuccessful = true,
                StatusCode = StatusCodes.Status201Created
            };
        }
    }
}
