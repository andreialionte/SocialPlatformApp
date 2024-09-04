using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialPlatformApp.Business.Implementations;
using SocialPlatformApp.Business.Interfaces;
using SocialPlatformApp.Repos.Extensions;

namespace SocialPlatformApp.Business.Extensions
{
    public static class BusinessRegistration
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDependeciesForRepo(configuration);
            /*            services.Dependecies();*/
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            /*            services.AddScoped(typeof(ITokenService), typeof(TokenService));*/
            services.AddScoped<IChatMessageService, ChatMessageService>();
            services.AddScoped<IFriendService, FriendService>();
            services.AddScoped<IFriendRequestService, FriendRequestService>();
            services.AddScoped<IPusherService, PusherService>();

            var ablyApiKey = configuration.GetSection("Ably:Key");

            services.AddSingleton<AblyChatService>(s => new AblyChatService(ablyApiKey.ToString()));
        }
    }
}
