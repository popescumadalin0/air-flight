using System;
using System.Threading.Tasks;
using AirFlightsDashboard.Models;
using AirFlightsDashboard.States;
using Microsoft.AspNetCore.Components;

namespace AirFlightsDashboard.Pages.Account;

public partial class Register : ComponentBase, IDisposable
{
    [Inject]
    private SnackbarState SnackbarState { get; set; }

    [Inject]
    private LoadingState LoadingState { get; set; }

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

    private Task RegisterAsync()
    {
        //todo: call database
        return Task.CompletedTask;
    }
}