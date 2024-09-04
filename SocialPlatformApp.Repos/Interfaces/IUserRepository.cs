using SocialPlatformApp.Models.Models;

namespace SocialPlatformApp.Repos.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetUsersByUserName(string userName);
    }
}
