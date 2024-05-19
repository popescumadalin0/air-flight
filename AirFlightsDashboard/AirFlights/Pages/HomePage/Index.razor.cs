using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace AirFlightsDashboard.Pages.HomePage;

public partial class Index
{
    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationState { get; set; }
    protected override async Task OnInitializedAsync()
    {
        var customAuth = await AuthenticationState;

        var a = customAuth.User.Identity.IsAuthenticated;
        var b = customAuth.User.Claims;
    }
}