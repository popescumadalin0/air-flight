using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using AirFlightsClient.States;
using SDK;

namespace AirFlightsClient;

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