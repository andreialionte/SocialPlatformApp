using SocialPlatformApp.Business.Interfaces;
using SocialPlatformApp.Models.Dtos;
using SocialPlatformApp.Repos.Interfaces;

namespace SocialPlatformApp.Business.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        /*        private readonly ITokenService _tokenService;*/

        public AuthService(IAuthRepository authRepository /*, ITokenService tokenService */)
        {
            _authRepository = authRepository;
            /*            _tokenService = tokenService;*/
        }

        public async Task<object> Register(UserForRegistrationDto userForRegistrationDto)
        {
            var user = await _authRepository.RegisterRepo(userForRegistrationDto);
            return user;
        }

        public async Task<object> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _authRepository.LoginRepo(userForLoginDto);
            /*            var token = _tokenService.JWTService(userForLoginDto.Email);*/
            return user;
        }

    }
}
