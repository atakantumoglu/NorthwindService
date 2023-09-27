//using AutoMapper;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using NorthwindService.Application.Cqrs.Commands.UserCommands;
//using NorthwindService.Application.ResponseObjects;
//using NorthwindService.Application.Services.Data.Abstract;
//using NorthwindService.Domain.Entities;
//using NorthwindService.Infrastructure.Data.Context;

//namespace NorthwindService.Application.Cqrs.CommandHandlers.UserCommandHandlers
//{
//    public sealed class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, ApiResponse>
//    {
//        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
//        private readonly IMapper _mapper;

//        public UserCreateCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, IMapper mapper)
//        {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//        }

//        public async Task<ApiResponse> Handle(UserCreateCommand request, CancellationToken cancellationToken)
//        {
//            User user = await _unitOfWork.GetReadOnlyRepositoryAsync<User>().SingleOrDefaultAsync(u => u.Email.Equals(request.Email));
//            if (user != null)
//            {
//                throw new Exception("This account is already exists");
//            }

//            await _unitOfWork.GetRepositoryAsync<User>().InsertAsync(_mapper.Map<User>(request));

//            await _unitOfWork.CommitAsync();


//            return new ApiResponse()
//            {
//                Data = request,
//                IsSuccessful = true,
//                StatusCode = StatusCodes.Status201Created
//            };
//        }
//    }
//}
