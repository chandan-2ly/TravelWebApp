using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Travel.IService;
using Travel.Repository;

namespace Travel.Service
{
    public static class ApplicationServicesRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();

            services.AddApplicationRepositories(configuration);
        }
    }
}
