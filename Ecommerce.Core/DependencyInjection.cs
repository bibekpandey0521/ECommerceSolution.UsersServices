using Ecommerce.Core.ServiceContracts;
using Ecommerce.Core.Services;
using Ecommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add Infrastructure
        /// services to the dependency injection container
     
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            // TO DO:Add services to the IoC container
            // Infrastructure services often include data
            // access, caching and other low-level components 
            services.AddTransient<IUsersService, UsersServices>();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            return services;
        }
    }
}
