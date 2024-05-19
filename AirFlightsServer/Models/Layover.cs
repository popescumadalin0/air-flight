using System;
using System.Collections.Generic;

namespace Models;

public class Layover
{
    public Guid Id { get; set; }

    public string StartPointCountry { get; set; }

    public string StartPointAirport { get; set; }

    public string DestinationAirport { get; set; }

    public DateTime DepartureTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public string DestinationCity { get; set; }

    public string DestinationCountry { get; set; }

    public string StartPointCity { get; set; }

    public int Order { get; set; }

    public string CompanyName { get; set; }

    public List<PlaneFacility> PlaneFacilities { get; set; }
}