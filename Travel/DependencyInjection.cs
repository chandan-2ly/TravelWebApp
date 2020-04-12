using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.IService;
using Travel.Service;

namespace Travel
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            #region Services

            services.AddTransient<IAuthenticateService, AuthenticateService>();

            #endregion
        }
    }
}
