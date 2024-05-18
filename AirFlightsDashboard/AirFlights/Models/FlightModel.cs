using System;

namespace AirFlightsDashboard.Models;

public class FlightModel
{
    public LocationModel FromLocation { get; set; }

    public LocationModel ToLocation { get; set; }

    public DateTime DepartureTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public int Price { get; set; }

    public string Currency { get; set; }

    public string Image { get; set; }
}