using System;

namespace AirFlightsDashboard.Models;

public class FlightFilter
{
    public string Leaving { get; set; }
    public string Going { get; set; }
    public DateTime Departing { get; set; }
    public DateTime Arriving { get; set; }
    public  int NoAdults { get; set; }
    public  int NoChildren { get; set; }
}