using System;
using System.Threading.Tasks;
using AirFlightsDashboard.Models;
using AirFlightsDashboard.States;
using Blazorise;
using Microsoft.AspNetCore.Components;
using SDK.Interfaces;

namespace AirFlightsDashboard.Pages.Flights;

public partial class Flight : BaseComponent
{
    [Parameter]
    public FlightModel FlightInfo { get; set; }

    [Inject]
    private IAirFlightsApiClient AirFlightsApiClient { get; set; }

    [Inject]
    private SnackbarState SnackbarState { get; set; }

    [Inject]
    private LoadingState LoadingState { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private void OnClick()
    {
        NavigationManager.NavigateTo($"ticket/{FlightInfo.Id.ToString()}");
    }

    private async Task OnDeleteAsync()
    {
        await LoadingState.ShowAsync();

        var response = await AirFlightsApiClient.DeleteTicketAsync(FlightInfo.Id);

        if (!response.Success)
        {
            await SnackbarState.PushAsync(response.ResponseMessage, true);
            await LoadingState.HideAsync();
            return;
        }

        await SnackbarState.PushAsync("Successfully deleted!");
        await LoadingState.HideAsync();
    }
}
