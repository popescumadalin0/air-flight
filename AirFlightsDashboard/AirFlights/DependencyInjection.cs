using System;
using AirFlightsDashboard.States;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SDK;

namespace AirFlightsDashboard;

/// <summary />
public static class DependencyInjection
{
    /// <summary />
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        var apiUrl = new Uri(config.GetSection("Api:BaseUrl").Value);
        services.AddAirFlightsApiClient(apiUrl);

        services.AddSingleton<SnackbarState>();
        services.AddSingleton<LoadingState>();

        return services;
    }
}