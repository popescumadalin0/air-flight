using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace AirFlightsDashboard.States;

public class AirFLightsAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ProtectedSessionStorage _sessionStorage;
    private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    public AirFLightsAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var token = await _sessionStorage.GetAsync<string>("token");
            if (string.IsNullOrEmpty(token.Value))
            {
                throw new Exception("Anonymous");
            }

            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(token.Value);

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

    public async Task<string> GetBearerTokenAsync(CancellationToken cancellationToken)
    {
        var token = await _sessionStorage.GetAsync<string>("token");

        return token.Value;
    }

    public async Task AuthenticateUserAsync(string token, string refreshToken)
    {
        await _sessionStorage.SetAsync("token", token);
        await _sessionStorage.SetAsync("refreshToken", refreshToken);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}