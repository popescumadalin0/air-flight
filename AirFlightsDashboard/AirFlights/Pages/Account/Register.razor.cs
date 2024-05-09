using System;
using System.Threading.Tasks;
using AirFlightsClient.Models;
using AirFlightsClient.States;
using Microsoft.AspNetCore.Components;

namespace AirFlightsClient.Pages.Account;

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