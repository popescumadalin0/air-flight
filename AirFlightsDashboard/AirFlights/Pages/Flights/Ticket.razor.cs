using AirFlightsDashboard.Models;
using Microsoft.AspNetCore.Components;

namespace AirFlightsDashboard.Pages.Flights;

public partial class Ticket
{
    [Parameter]
    public string Id { get; set; }

    private TicketModel TicketInfo = new TicketModel();

}