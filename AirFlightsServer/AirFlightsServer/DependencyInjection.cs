using Microsoft.Extensions.DependencyInjection;
using System;
using AirFlightsServer.Repositories;
using AirFlightsServer.Repositories.Interfaces;
using AirFlightsServer.Services;
using AirFlightsServer.Services.Interfaces;
using DataBaseLayout;
using Microsoft.Extensions.Configuration;

namespace AirFlightsServer
{
    public static class DependencyInjectionExt
    {
        /// <summary />
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDataLayout(config);

            services.AddScoped<IAirFlightRepository, AirFlightRepository>();
            //todo: continui tu

            services.AddScoped<IAirFlightService, AirFlightService>();
            //todo: continui tu

            return services;
        }
    }
}
