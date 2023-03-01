using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApiNuget
{
    public static class WeatherApiDependencyInjectionExtensions
    {
        public static IServiceCollection AddWeatherApi(this IServiceCollection services, Action<WeatherApiOptions> configure)
        {
            services.AddTransient<IWeatherApi, WeatherApi>();
            services.Configure(configure);
            return services;
        }
    }
}
