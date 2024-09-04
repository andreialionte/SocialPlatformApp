namespace SocialPlatformApp.Repos.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UsersRepo { get; }
        Task Commit();
    }
}
