using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace SocialPlatformApp.Common.Extensions
{
    public static class RegisterCommon
    {
        public static void Dependecies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperConfiguration));

        }
    }
}
