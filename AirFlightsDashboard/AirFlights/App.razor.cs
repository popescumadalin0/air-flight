using AirFlightsClient.States;
using Microsoft.AspNetCore.Components;
using System;

namespace AirFlightsClient;

public partial class App : IDisposable
{
    [Inject]
    private SnackbarState SnackbarState { get; set; }

    [Inject]
    private LoadingState LoadingState { get; set; }

    protected override void OnInitialized()
    {
        SnackbarState.OnStateChange += StateHasChanged;
        LoadingState.OnStateChange += StateHasChanged;
    }

    public void Dispose()
    {
        SnackbarState.OnStateChange -= StateHasChanged;
        LoadingState.OnStateChange -= StateHasChanged;
    }
}