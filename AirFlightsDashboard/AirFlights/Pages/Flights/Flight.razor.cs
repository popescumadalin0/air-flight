using System;
using AirFlightsDashboard.Models;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace AirFlightsDashboard.Pages.Flights;

public partial class Flight : BaseComponent
{
    [Parameter]
    public FlightModel FlightInfo { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private void OnClick()
    {
        NavigationManager.NavigateTo("todo");
    }
}
