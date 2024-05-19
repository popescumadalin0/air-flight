using System;
using System.Collections.Generic;

namespace Models;

public class TicketDetail
{
    public Guid Id { get; set; }

    public int Price { get; set; }

    public string Currency { get; set; }

    public List<Layover> Layovers { get; set; }

    public int NumberOfSeats { get; set; }

    public string Image { get; set; }
}