using Microsoft.Extensions.DependencyInjection;
using System;
using AirFlightsServer.Repositories;
using AirFlightsServer.Repositories.Interfaces;
using AirFlightsServer.Services;
using AirFlightsServer.Services.Interfaces;
using DataBaseLayout;
using Microsoft.Extensions.Configuration;

namespace AirFlightsServer;

public static class DependencyInjectionExt
{
    /// <summary />
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDataLayout(config);

        services.AddScoped<IAirFlightRepository, AirFlightRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ILayoverRepository, LayoverRepository>();
        //todo: continui tu

        services.AddScoped<IAirFlightService, AirFlightService>();
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ILayoverService, LayoverService>();
        //todo: continui tu

        return services;
    }
}