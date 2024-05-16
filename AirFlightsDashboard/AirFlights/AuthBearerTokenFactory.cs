using Blazored.LocalStorage;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AirFlightsDashboard;

public class AuthHeaderHandler : DelegatingHandler
{
    private readonly ILocalStorageService _localStorageService;

    public AuthHeaderHandler(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var auth = request.Headers.Authorization;

        if (auth != null)
        {
            if (await _localStorageService.ContainKeyAsync("token"))
            {
                string token = await _localStorageService.GetItemAsync<string>("token");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}