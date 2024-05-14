using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace AirFlightsDashboard.Shared;

public partial class NavMenu
{
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    private bool _collapseNavMenu = true;

    private bool _isAuthenticated = false;

    private string? NavMenuCssClass => _collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        _collapseNavMenu = !_collapseNavMenu;
    }

    protected override async Task OnInitializedAsync()
    {
        var userClaims = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        _isAuthenticated = userClaims.User.Identity?.IsAuthenticated ?? false;
    }
}