using System;
using AirFlightsDashboard.Services;
using AirFlightsDashboard.States;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using SDK;
using SDK.Interfaces;

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

        services.AddSingleton<ApplicationSession>();

        services.AddAuthorizationCore();

        services.AddScoped<
            AirFLightsAuthenticationStateProvider,
            AirFLightsAuthenticationStateProvider>();

        services.AddScoped<AuthenticationStateProvider>(
            p => p.GetService<AirFLightsAuthenticationStateProvider>());

        var authProvider = services.BuildServiceProvider().GetService<AirFLightsAuthenticationStateProvider>();
        AuthBearerTokenFactory.SetBearerTokenGetterFunc(authProvider!.GetBearerTokenAsync);

        services.AddTransient<AuthHeaderHandler>();
        var apiUrl = new Uri(config.GetSection("Api:BaseUrl").Value);
        services.AddAirFlightsApiClient(apiUrl);

        services.AddRefitClient<IAirFlightsApi>()
            .ConfigureHttpClient(c => c.BaseAddress = apiUrl).AddHttpMessageHandler<AuthHeaderHandler>();

        services.AddScoped<SnackbarState>();
        services.AddScoped<LoadingState>();

        return services;
    }
}