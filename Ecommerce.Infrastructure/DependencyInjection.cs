using Ecommerce.Core.RepositoryContracts;
using Ecommerce.Infrastructure.DbContext;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure
{
    public static  class DependencyInjection
    {
        /// <summary>
        /// Extension method to add Infrastructure
        /// services to the dependency injection container
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            // TO DO: Add services to the IoC Container
            // Infrastructure services often include data
            // access , caching and other low-level components
            services.AddTransient<IUsersRepository, UsersRepository>();

            services.AddTransient<DapperDbContext>();
            return services;
        }
    }
}
