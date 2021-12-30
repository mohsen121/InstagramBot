using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using InstagramBot.Core.Configs;

namespace InstagramBot.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<InstagramUserCredential>(configuration.GetSection("InstagramUserCredential"));

            return services;
        }
    }
}
