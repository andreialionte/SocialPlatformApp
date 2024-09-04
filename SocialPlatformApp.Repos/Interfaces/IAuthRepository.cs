using SocialPlatformApp.Models.Dtos;

namespace SocialPlatformApp.Repos.Interfaces
{
    public interface IAuthRepository
    {
        Task<object> RegisterRepo(UserForRegistrationDto user);
        Task<object> LoginRepo(UserForLoginDto user);
    }
}
