using CalendarAPI.Repositories;
using CalendarAPI.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigServiceExtensions
    {
        public static IServiceCollection AddDependencyGroup(
             this IServiceCollection services)
        {
            services.AddSingleton<IContext, Context>();
            services.AddScoped<IUserDateTimeRepository, UserDateTimeRepository>();
            services.AddScoped<IUserDateTimeService, UserDateTimeService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}