using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AirFlightsDashboard.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace AirFlightsDashboard.States;

public class AirFLightsAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly ApplicationSession _session;
    private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    public AirFLightsAuthenticationStateProvider(ILocalStorageService localStorage, ApplicationSession session)
    {
        _localStorage = localStorage;
        _session = session;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            if (string.IsNullOrEmpty(_session.GetItem("token")))
            {
                var token = await _localStorage.GetItemAsync<string>("token");
                var refreshToken = await _localStorage.GetItemAsync<string>("refreshToken");
                _session.SetItem("token", token);
                _session.SetItem("refreshToken", refreshToken);
            }

            if (string.IsNullOrEmpty(_session.GetItem("token")))
            {
                throw new Exception("Anonymous");
            }

            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(_session.GetItem("token"));

            var identity = new ClaimsIdentity(
                decodedToken.Claims,
                "jwt",
                decodedToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value,
                decodedToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value);
            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }
        catch (Exception)
        {
            return new AuthenticationState(_anonymous);
        }
    }

    //todo: move this into a singleton service
    public async Task<string> GetBearerTokenAsync(CancellationToken cancellationToken)
    {
        var token = _session.GetItem("token");

        return token;
    }

    public async Task AuthenticateUserAsync(string token, string refreshToken)
    {
        await _localStorage.SetItemAsync("token", token);
        await _localStorage.SetItemAsync("refreshToken", refreshToken);

        _session.SetItem("token", token);
        _session.SetItem("refreshToken", refreshToken);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}