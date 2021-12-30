using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramBot.Core.Interfaces;
using InstagramBot.Infrustracture.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InstagramBot.Infrustracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrustracture(this IServiceCollection services)
        {
            services.AddSingleton<IInstagramService, InstagramService>();
            return services;
        }
    }
}
