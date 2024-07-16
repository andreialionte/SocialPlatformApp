using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialPlatformApp.Repos.Extensions;

namespace SocialPlatformApp.Business.Extensions
{
    public static class BusinessRegistration
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDependeciesForRepo(configuration);
        }
    }
}
