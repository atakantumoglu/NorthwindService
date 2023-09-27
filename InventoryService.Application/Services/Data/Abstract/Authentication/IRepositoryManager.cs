namespace NorthwindService.Application.Services.Data.Abstract.Authentication
{
    public interface IRepositoryManager
    {
        IUserAuthenticationRepository UserAuthentication { get; }
        Task SaveAsync();
    }
}
