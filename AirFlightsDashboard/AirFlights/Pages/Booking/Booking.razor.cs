using AirFlightsDashboard.Models;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace AirFlightsDashboard.Pages.Booking;

public partial class Booking : BaseComponent
{
    private PersonalDetails personalDetails;

    private Seats seats;

    [Parameter]
    public BookingModel BookingForm { get; set; } = new BookingModel();

    [Parameter]
    public CompanyModel Company { get; set; } = new CompanyModel();

}
