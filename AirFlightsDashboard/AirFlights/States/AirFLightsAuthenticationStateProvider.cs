using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AirFlightsDashboard.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace AirFlightsDashboard.States;

public class AirFLightsAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _httpClient;
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
                return new AuthenticationState(_anonymous);
            }

            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(_session.GetItem("token"));

            var identity = new ClaimsIdentity(
                decodedToken.Claims.ToList(),
                "jwt");
            /*decodedToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value,
            decodedToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value);*/
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }
        catch (Exception)
        {
            return new AuthenticationState(_anonymous);
        }
    }

    public async Task<string> GetBearerTokenAsync(CancellationToken cancellationToken)
    {
        var token = "test";// _session.GetItem("token");

        return token;
    }

    public async Task AuthenticateUserAsync(string token, string refreshToken)
    {
        await _localStorage.SetItemAsync("token", token);
        await _localStorage.SetItemAsync("refreshToken", refreshToken);

        _session.SetItem("token", token);
        _session.SetItem("refreshToken", refreshToken);

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task LogoutUserAsync()
    {
        await _localStorage.SetItemAsync("token", string.Empty);
        await _localStorage.SetItemAsync("refreshToken", string.Empty);

        _session.SetItem("token", string.Empty);
        _session.SetItem("refreshToken", string.Empty);

        _httpClient.DefaultRequestHeaders.Authorization = null;

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
    }
}