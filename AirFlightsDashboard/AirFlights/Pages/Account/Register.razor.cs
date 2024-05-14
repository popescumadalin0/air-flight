using System;
using System.Threading.Tasks;
using AirFlightsDashboard.Models;
using AirFlightsDashboard.States;
using Microsoft.AspNetCore.Components;
using Models;
using Models.Request;
using SDK.Interfaces;

namespace AirFlightsDashboard.Pages.Account;

public partial class Register : ComponentBase, IDisposable
{
    [Inject]
    private SnackbarState SnackbarState { get; set; }

    [Inject]
    private LoadingState LoadingState { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    [Inject]
    private IAirFlightsApiClient AirFlightsApiClient { get; set; }

    private RegisterModel _registerModel = new RegisterModel();

    public void Dispose()
    {
        SnackbarState.OnStateChange -= StateHasChanged;
        LoadingState.OnStateChange += StateHasChanged;
    }

    protected override void OnInitialized()
    {
        SnackbarState.OnStateChange += StateHasChanged;
        LoadingState.OnStateChange += StateHasChanged;
    }

    private async Task RegisterAsync()
    {
        await LoadingState.ShowAsync();
        var result = await AirFlightsApiClient.RegisterUserAsync(
            new UserRegister()
            {
                Password = _registerModel.Password,
                User = new User()
                {
                    CNP = _registerModel.CNP,
                    Email = _registerModel.Email,
                    FirstName = _registerModel.FirstName,
                    LastName = _registerModel.LastName,
                    PhoneNumber = _registerModel.PhoneNumber,
                    ProfileImageFileName = _registerModel.FirstName,
                    ProfileImageName = _registerModel.FirstName,
                    UserName = _registerModel.UserName
                }
            });

        await LoadingState.HideAsync();

        await SnackbarState.PushAsync(
            result.Success ? "User created!" : result.ResponseMessage,
            result.Success);

        if (result.Success)
        {
            NavigationManager.NavigateTo("/login");
        }
    }
}