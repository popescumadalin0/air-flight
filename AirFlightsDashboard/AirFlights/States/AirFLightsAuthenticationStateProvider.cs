using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace AirFlightsDashboard.States;

public class AirFLightsAuthenticationStateProvider : AuthenticationStateProvider
{

    private readonly ISessionStorageService _sessionStorageService;
    private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    public AirFLightsAuthenticationStateProvider(ISessionStorageService sessionStorageService)
    {
        _sessionStorageService = sessionStorageService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        /*var token = await _sessionStorageService.GetItemAsync<string>("token");
    if (string.IsNullOrEmpty(token))
    {
        return new AuthenticationState(_anonymous);
    }
    var identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt");*/
        var user = new ClaimsPrincipal();

        return await Task.FromResult(new AuthenticationState(user));
    }

    public async Task<string> GetBearerTokenAsync(CancellationToken cancellationToken)
    {
        var token = await _sessionStorageService.GetItemAsync<string>("token");

        return token;
    }

    public void AuthenticateUser(string token, string refreshToken)
    {
        /*var identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt");*/
        var user = new ClaimsPrincipal();
        var state = new AuthenticationState(user);
        NotifyAuthenticationStateChanged(Task.FromResult(state));
    }
}