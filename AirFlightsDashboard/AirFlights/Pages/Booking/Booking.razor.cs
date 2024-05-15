using System;
using AirFlightsDashboard.Models;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace AirFlightsDashboard.Pages.Booking;

public partial class Booking : BaseComponent
{
    private PersonalDetails personalDetails;
private PersonalDetails personalDetails;
    [Parameter]
    public FlightModel BookingForm { get; set; }

    [Parameter]
    public CompanyModel Company { get; set; }


}
