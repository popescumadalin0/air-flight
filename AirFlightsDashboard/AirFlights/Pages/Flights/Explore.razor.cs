using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirFlightsDashboard.Models;
using Microsoft.AspNetCore.Components;

namespace AirFlightsDashboard.Pages.Flights;

public partial class Explore : ComponentBase
{
    private FlightFilter _filter;

    private List<FlightModel> flights;

    protected override Task OnInitializedAsync()
    {
        //se apleaza baza
        flights = new List<FlightModel>()
        {
            new FlightModel()
            {
                DepartureTime = DateTime.Now,
                StartPointAirport = "Bucharest",
                DestinationCountry = "Anglia",
                ArrivalTime = DateTime.Now,
                DestinationAirport = "Anglia",
                DestinationCity = "Londra",
                StartPointCity = "Bucharest",
                StartPointCountry = "Romania",
                Currency = "Ron",
                Price = 120
            }
        };

        return base.OnInitializedAsync();
    }

    private Task DepartingChangedAsync(DateTime value)
    {
        _filter.Departing = value;
        //se apleaza iar baza
        flights = new List<FlightModel>();

        return Task.CompletedTask;
    }
}