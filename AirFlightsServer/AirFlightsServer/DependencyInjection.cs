using Microsoft.Extensions.DependencyInjection;
using System;
using AirFlightsServer.Repositories;
using AirFlightsServer.Repositories.Interfaces;
using AirFlightsServer.Services;
using AirFlightsServer.Services.Interfaces;
using DataBaseLayout;
using Microsoft.Extensions.Configuration;

namespace AirFlightsServer;

public static class DependencyInjection
{
    /// <summary />
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDataLayout(config);

        services.AddScoped<IAirFlightRepository, AirFlightRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ILayoverRepository, LayoverRepository>();
        services.AddScoped<IPlaneFacilityRepository, PlaneFacilityRepository>();
        services.AddScoped<IPlaneSeatRepository, PlaneSeatRepository>();

        services.AddScoped<IAirFlightService, AirFlightService>();
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ILayoverService, LayoverService>();
        services.AddScoped<IPlaneFacilityService, PlaneFacilityService>();
        services.AddScoped<IPlaneSeatService, PlaneSeatService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}