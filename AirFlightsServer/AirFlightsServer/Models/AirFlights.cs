using System;

namespace AirFlightsServer.Models
{
    public class AirFlights
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public string Currency { get; set; }
    }
}
