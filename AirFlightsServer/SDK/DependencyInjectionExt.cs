using System;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using SDK.Clients;
using SDK.Interfaces;

namespace SDK;

/// <summary />
public static class DependencyInjectionExt
{
    /// <summary />
    public static IServiceCollection AddAirFlightsApiClient(this IServiceCollection services, Uri url)
    {
        RefitSettings refitSettings = new()
        {
            AuthorizationHeaderValueGetter = (_, cancellationToken) => AuthBearerTokenFactory.GetBearerTokenAsync(cancellationToken)
        };
        services.AddRefitClient<IAirFlightsApi>(refitSettings)
            .ConfigureHttpClient(c => c.BaseAddress = url);

        services.AddSingleton<IAirFlightsApiClient, AirFlightsApiClient>();
        return services;
    }
}