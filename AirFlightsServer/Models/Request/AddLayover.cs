using System;
using System.Collections.Generic;

namespace Models.Request;

public class AddLayover
{
    public Guid Id { get; set; }

    public string StartPointCountry { get; set; }

    public string StartPointAirport { get; set; }

    public string DestinationAirport { get; set; }

    public DateTime DepartureTime { get; set; }

    public DateTime ArrivalDuration { get; set; }

    public string DestinationCity { get; set; }

    public string DestinationCountry { get; set; }

    public string StartPointCity { get; set; }

    public int Order { get; set; }

    public string CompanyName { get; set; }

    public int PlaneSeats { get; set; }

    public List<AddPlaneFacility> PlaneFacilities { get; set; }
}