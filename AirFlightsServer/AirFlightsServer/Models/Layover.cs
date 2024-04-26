using System;

namespace AirFlightsServer.Models
{
    public class Layover
    {
        public Guid Id { get; set; }
        public string StartPointCountry { get; set; }
        public string StartPointAirport { get; set; }
        public string DestinationAirport { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime FlightDuration { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationCountry { get; set; }
        public string StartPointCity { get; set; }
    }
}
