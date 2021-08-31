using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Travel.Entities;
using Travel.IRepository;

namespace Travel.Repository
{
    public static class ApplicationRepositoriesRegistration
    {
        public static void AddApplicationRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TravelContext>(op =>
            {
                op.UseSqlServer(configuration["ConnectionString"],
                    optionBuilder => optionBuilder.MigrationsAssembly("Travel.Repository"));
            });

            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
