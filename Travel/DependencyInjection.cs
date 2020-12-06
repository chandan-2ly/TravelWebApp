using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Travel.Entities;
using Travel.IRepository;
using Travel.IService;
using Travel.Repository;
using Travel.Service;

namespace Travel
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            
            #region Repository

            services.AddTransient<IUserRepository, UserRepository>();

            #endregion

            #region Services

            services.AddTransient<IUserService, UserService>();

            #endregion
        }
    }
}
