using System;

namespace Models;

public class Ticket
{
    public Guid Id { get; set; }

    public int Price { get; set; }

    public string Currency { get; set; }

    public string FromCountry { get; set; }

    public string ToCountry { get; set; }

    public string FromCity { get; set; }

    public string ToCity { get; set; }

    public DateTime DepartureTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public int NumberOfSeats { get; set; }

    public string Image { get; set; }
}