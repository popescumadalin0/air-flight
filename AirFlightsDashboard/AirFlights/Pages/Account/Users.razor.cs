using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirFlightsDashboard.States;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Models;
using SDK.Interfaces;

namespace AirFlightsDashboard.Pages.Account;

public partial class Users : ComponentBase, IDisposable
{
    [Inject]
    private SnackbarState SnackbarState { get; set; }

    [Inject]
    private LoadingState LoadingState { get; set; }

    [Inject]
    private IAirFlightsApiClient AirFlightsApiClient { get; set; }

    private List<User> _users = new();

    private User _selectedUser = new();
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

        var response = await AirFlightsApiClient.GetUsersAsync();

        if (!response.Success)
        {
            await SnackbarState.PushAsync(response.ResponseMessage, true);
            await LoadingState.HideAsync();
            return;
        }

        _users = response.Response;

        await LoadingState.HideAsync();
    }

    private async Task SaveAsync(MouseEventArgs context)
    {
        //todo:
    }
}