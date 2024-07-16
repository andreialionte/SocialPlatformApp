using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialPlatformApp.Repos.DataLayer;

namespace SocialPlatformApp.Repos.Extensions
{
    public static class RegisterRepo
    {
        public static void RegisterDependeciesForRepo(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(opts => opts.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
