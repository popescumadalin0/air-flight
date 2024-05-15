using System;
using AirFlightsDashboard.States;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
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
        services.AddCascadingAuthenticationState();

        services.AddAuthorizationCore();

        services.AddBlazoredSessionStorage();
        services.AddBlazoredLocalStorage();
        services.AddScoped<ProtectedSessionStorage>();

        services.AddScoped<AuthenticationStateProvider, AirFLightsAuthenticationStateProvider>();

        var authProvider = services.BuildServiceProvider().GetService<AuthenticationStateProvider>();
        AuthBearerTokenFactory.SetBearerTokenGetterFunc(((AirFLightsAuthenticationStateProvider)authProvider)!.GetBearerTokenAsync);

        var apiUrl = new Uri(config.GetSection("Api:BaseUrl").Value);
        services.AddAirFlightsApiClient(apiUrl);

        services.AddSingleton<SnackbarState>();
        services.AddSingleton<LoadingState>();

        return services;
    }
}