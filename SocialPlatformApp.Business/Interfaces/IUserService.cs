using SocialPlatformApp.Models.Dtos;
using SocialPlatformApp.Models.Models;

namespace SocialPlatformApp.Business.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(UserDto userDto);
        Task<User> UpdateUser(int userId, UserDto userDto);
        Task DeleteUser(int userId);
        Task<User> GetUser(int userId);
        Task<List<User>> GetUsers();
        Task<List<User>> GetUserByTheUserName(string userName);
    }
}
