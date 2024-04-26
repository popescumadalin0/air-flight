using System;
using AirFlightsServer.SDK.Clients;
using AirFlightsServer.SDK.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AirFlightsServer.SDK;

/// <summary />
public static class DependencyInjectionExt
{
    /// <summary />
    public static IServiceCollection AddAirFlightsApiClient(this IServiceCollection services, Uri url)
    {
        services.AddRefitClient<IAirFlightsApi>()
            .PlaneFacilityureHttpClient(c => c.BaseAddress = url);

        services.AddSingleton<IAirFlightsApiClient, AirFlightsApiClient>();
        return services;
    }
}