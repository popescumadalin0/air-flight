using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AirFlightsDashboard.Models;
using AirFlightsDashboard.States;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Models;
using SDK.Interfaces;

namespace AirFlightsDashboard.Pages.Account;

public partial class Details : ComponentBase, IDisposable
{
    [Inject]
    private SnackbarState SnackbarState { get; set; }

    [Inject]
    private LoadingState LoadingState { get; set; }

    [Inject]
    private IAirFlightsApiClient AirFlightsApiClient { get; set; }

    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationState { get; set; }

    private AccountDetailsModel _user = new();

    public void Dispose()
    {
        SnackbarState.OnStateChange -= StateHasChanged;
        LoadingState.OnStateChange += StateHasChanged;
    }

    protected override async Task OnInitializedAsync()
    {
        SnackbarState.OnStateChange += StateHasChanged;
        LoadingState.OnStateChange += StateHasChanged;

        await LoadingState.ShowAsync();

        var authState = await AuthenticationState;

        var user = await AirFlightsApiClient.GetUserAsync(
            authState.User.Claims.First(uc => uc.Type == ClaimTypes.SerialNumber).Value);

        if (!user.Success)
        {
            await SnackbarState.PushAsync(user.ResponseMessage, !user.Success);
            await LoadingState.HideAsync();
            return;
        }

        _user = new AccountDetailsModel()
        {
            ProfileImage = user.Response.ProfileImage,
            FirstName = user.Response.FirstName,
            LastName = user.Response.LastName,
            CNP = user.Response.CNP,
            Email = user.Response.Email,
            PhoneNumber = user.Response.PhoneNumber,
            UserName = user.Response.UserName,
        };

        await LoadingState.HideAsync();
    }
}