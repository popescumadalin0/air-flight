using System;
using System.Threading.Tasks;
using AirFlightsDashboard.Models;
using AirFlightsDashboard.States;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Models.Request;
using SDK.Interfaces;

namespace AirFlightsDashboard.Pages.Account;

public partial class Login : ComponentBase, IDisposable
{
    [Inject]
    private SnackbarState SnackbarState { get; set; }

    [Inject]
    private LoadingState LoadingState { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject]
    private IAirFlightsApiClient AirFlightsApiClient { get; set; }

    private LoginModel _loginModel = new LoginModel();

    public void Dispose()
    {
        SnackbarState.OnStateChange -= StateHasChanged;
        LoadingState.OnStateChange -= StateHasChanged;
    }

    protected override void OnInitialized()
    {
        SnackbarState.OnStateChange += StateHasChanged;
        LoadingState.OnStateChange += StateHasChanged;
    }

    private async Task SignInAsync()
    {
        await LoadingState.ShowAsync();
        var result = await AirFlightsApiClient.LoginUserAsync(
            new UserLogin
            {
                Password = _loginModel.Password,
                Email = _loginModel.Username
            });

        await LoadingState.HideAsync();

        await SnackbarState.PushAsync(
            result.Success ? "User logged!" : result.ResponseMessage,
            !result.Success);

        if (result.Success)
        {
            var customProvider = (AirFLightsAuthenticationStateProvider)AuthenticationStateProvider;
            await customProvider.AuthenticateUserAsync(result.Response.AccessToken, result.Response.RefreshToken);

            NavigationManager.NavigateTo("/");
        }
    }
}