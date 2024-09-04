using SocialPlatformApp.Models.Dtos;

namespace SocialPlatformApp.Business.Interfaces
{
    public interface IAuthService
    {
        Task<object> Login(UserForLoginDto userForLoginDto);
        Task<object> Register(UserForRegistrationDto userForRegistrationDto);
    }
}
