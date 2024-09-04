using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialPlatformApp.Common.Extensions;
using SocialPlatformApp.Repos.DataLayer;
using SocialPlatformApp.Repos.Interfaces;
using SocialPlatformApp.Repos.Repositories;

namespace SocialPlatformApp.Repos.Extensions
{
    public static class RegisterRepo
    {
        public static void RegisterDependeciesForRepo(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(opts => opts.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.Dependecies();
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IAuthRepository), typeof(AuthRepository));
            services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
            services.AddScoped<IFriendRepository, FriendRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IFriendRequestRepository, FriendRequestRepository>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opts =>
    {
        opts.SaveToken = true;
        opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = "http://localhost:4200",
            ValidIssuer = "http://localhost:4200"
            /*            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TokenKey"))*/
        };
    });
            /*            services.AddControllers().AddJsonOptions(options =>
                        {
                            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                        });*/

        }
    }
}
